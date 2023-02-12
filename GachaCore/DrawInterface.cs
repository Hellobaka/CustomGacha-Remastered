using GachaCore.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace GachaCore
{
    public class PluginExecutor
    {
        private string PluginPath { get; set; } = "";

        private Assembly Plugin { get; set; }

        /// <summary>
        /// 绘制核心图片
        /// </summary>
        public object DrawMainImage { get; set; }

        /// <summary>
        /// 绘制抽卡子项目
        /// </summary>
        public object DrawItem { get; set; }

        /// <summary>
        /// 获取绘制坐标
        /// </summary>
        public object DrawPoints { get; set; }

        /// <summary>
        /// 最终绘制
        /// </summary>
        public object FinallyDraw { get; set; }

        /// <summary>
        /// 绘制全部项目
        /// </summary>
        public object DrawAllItems { get; set; }

        public PluginExecutor(string pluginPath)
        {
            PluginPath = pluginPath;
        }

        /// <summary>
        /// 加载插件
        /// </summary>
        /// <exception cref="FileLoadException"></exception>
        /// <exception cref="ReflectionTypeLoadException"></exception>
        public void LoadPlugin()
        {
            if (File.Exists(PluginPath))
            {
                byte[] fsContent;
                try
                {
                    using (FileStream fs = File.OpenRead(PluginPath))
                    {
                        fsContent = new byte[fs.Length];
                        fs.Read(fsContent, 0, fsContent.Length);
                    }
                    Plugin = Assembly.Load(fsContent);
                }
                catch (Exception e)
                {
                    Common.Info("LoadPlugin", $"插件加载失败，使用默认接口实现: {e.Message}\n{e.StackTrace}");
                    LoadLocalAssembly();
                }
            }
            else
            {
                Common.Info("LoadPlugin", $"FileLoadException: 插件 {PluginPath} 文件不存在，使用默认接口实现。");
                LoadLocalAssembly();
            }
        }

        public void LoadLocalAssembly()
        {
            Plugin = Assembly.GetAssembly(typeof(DefaultDrawImplement));
        }

        public void CreateInterfaceInstance()
        {
            bool exceptionFlag = false;
            DrawMainImage = null;
            DrawItem = null;
            DrawPoints = null;
            FinallyDraw = null;
            DrawAllItems = null;
            GC.Collect();
            try
            {
                foreach (var item in Plugin.GetTypes())
                {
                    if (item.GetInterface("IDrawMainImage") != null)
                    {
                        DrawMainImage = Plugin.CreateInstance(item.FullName);
                    }

                    if (item.GetInterface("IDrawItem") != null)
                    {
                        DrawItem = Plugin.CreateInstance(item.FullName);
                    }

                    if (item.GetInterface("IDrawPoints") != null)
                    {
                        DrawPoints = Plugin.CreateInstance(item.FullName);
                    }

                    if (item.GetInterface("IFinallyDraw") != null)
                    {
                        FinallyDraw = Plugin.CreateInstance(item.FullName);
                    }

                    if (item.GetInterface("IDrawAllItems") != null)
                    {
                        DrawAllItems = Plugin.CreateInstance(item.FullName);
                    }
                }
            }
            catch (ReflectionTypeLoadException e)
            {
                exceptionFlag = true;
                Common.Info("LoadPlugin", $"插件反射失败: {e.LoaderExceptions[0].Message}\n{e.StackTrace}");
            }
            catch (Exception e)
            {
                exceptionFlag = true;
                Common.Info("LoadPlugin", $"Exception: {e.Message}\n{e.StackTrace}");
            }
            finally
            {
                if (exceptionFlag)
                {
                    LoadLocalAssembly();
                    CreateInterfaceInstance();
                }
            }
        }
    }

    // IDrawPoints -> IDrawMainImage -> IDrawItem -> IDrawAllItems -> IFinallyDraw
    public class DefaultDrawImplement : IDrawItem, IDrawPoints, IDrawAllItems
    {
        public Bitmap DrawAllItems(List<Image> allItemImages, List<GachaItem> gachaItems, Point[] drawPoints, Bitmap backgroundImg, Pool pool)
        {
            using Graphics g = Graphics.FromImage(backgroundImg);
            Bitmap newImage = null;
            if(File.Exists(Path.Combine(pool.RelativePath, pool.NewPicPath)))
            {
                newImage = (Bitmap)Image.FromFile(Path.Combine(pool.RelativePath, pool.NewPicPath));
            }
            int index = 0;
            foreach (var item in allItemImages)
            {
                g.DrawImage(item, new Rectangle(drawPoints[index], item.Size));
                if (gachaItems[index].IsNew && newImage != null)
                {
                    Point newPoint = new Point(drawPoints[index].X + pool.NewPicX, drawPoints[index].Y + pool.NewPicY);
                    g.DrawImage(newImage, new Rectangle(newPoint, new Size(pool.NewPicWidth, pool.NewPicHeight)));
                }

                index++;
            }
            newImage.Dispose();
            return backgroundImg;
        }

        public Bitmap DrawPicItem(GachaItem item, Pool pool, Bitmap mainImage)
        {
            //不需要合成时请填写图片路径，忽略背景路径
            string backgroundImagePath = Path.Combine(pool.RelativePath, item.BackgroundImagePath);
            string imagePath = Path.Combine(pool.RelativePath, item.MainImagePath);
            bool nobackgroundFlag = string.IsNullOrWhiteSpace(item.BackgroundImagePath);

            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException($"卡片的图片文件不存在，在卡 {item.Name} 中 路径{imagePath}");
            }
            if (nobackgroundFlag is false && !File.Exists(backgroundImagePath))
            {
                throw new FileNotFoundException($"卡片的背景图片文件不存在，在卡 {item.Name} 中 路径{imagePath}");
            }

            ItemDrawConfig imageConfig = pool.ItemDrawConfig;
            Point drawPoint = new Point(imageConfig.ImagePointX, imageConfig.ImagePointY);
            Size destSize = new Size(imageConfig.ImageWidth, imageConfig.ImageHeight);
            Size backGroundReSizeSize = new Size(imageConfig.BackgroundImageWidth, imageConfig.BackgroundImageHeight);
            if (!string.IsNullOrWhiteSpace(item.BackgroundImagePath))
            {
                Image background = Image.FromFile(backgroundImagePath);
                Bitmap backgroundResize = new Bitmap(background, backGroundReSizeSize);
                switch (imageConfig.DrawOrder)
                {
                    case DrawOrder.ImageAboveBackground:
                        using (Graphics g = Graphics.FromImage(backgroundResize))
                        {
                            g.DrawImage(mainImage, new Rectangle(drawPoint, destSize));
                        }
                        break;
                    case DrawOrder.ImageBelowBackground:
                        Bitmap emptyBitmap = new Bitmap(imageConfig.BackgroundImageWidth, imageConfig.BackgroundImageHeight);
                        using (Graphics g = Graphics.FromImage(emptyBitmap))
                        {
                            g.DrawImage(mainImage, new Rectangle(drawPoint, destSize));
                            g.DrawImage(backgroundResize, new Point(0, 0));
                            backgroundResize = emptyBitmap;
                        }
                        break;
                }
                return backgroundResize;
            }
            else
            {
                Bitmap destBitmap = new Bitmap(mainImage, new Size(imageConfig.ImageWidth, imageConfig.ImageHeight));
                mainImage.Dispose();
                return destBitmap;
            }
        }

        public Point[] GetDrawPoints(Pool pool, int count)
        {
            Point[] drawPoints = new Point[count];
            int x = pool.PoolDrawConfig.StartPointX, y = pool.PoolDrawConfig.StartPointY;
            for (int i = 0; i < drawPoints.Length; i++)
            {
                drawPoints[i] = new Point(x, y);
                if (x >= pool.PoolDrawConfig.MaxX && pool.PoolDrawConfig.MaxX != 0)
                {
                    x = pool.PoolDrawConfig.XChange + pool.PoolDrawConfig.StartPointX;
                    y = pool.PoolDrawConfig.YChange + pool.PoolDrawConfig.StartPointY;
                }
                else
                {
                    if (pool.ItemDrawConfig.BackgroundImageWidth != 0)
                    {
                        x += pool.PoolDrawConfig.DrawXInterval + pool.ItemDrawConfig.BackgroundImageWidth;
                    }
                    else
                    {
                        x += pool.PoolDrawConfig.DrawXInterval + pool.ItemDrawConfig.ImageWidth;
                    }
                    y += pool.PoolDrawConfig.DrawYInterval;
                }
            }
            return drawPoints;
        }
    }

    /// <summary>
    /// 自定义所有项目的绘制方式.
    /// 实现该接口后, 原本的自带默认（坐标运算）绘制将失效
    /// </summary>
    public interface IDrawAllItems
    {
        /// <summary>
        /// 自定义所有子项目的绘制
        /// </summary>
        /// <param name="allItemImages">所有子项目图片</param>
        /// <param name="gachaItems">图片对应的项目</param>
        /// <param name="drawPoints">绘制的坐标</param>
        /// <param name="backgroundImg">背景图片</param>
        /// <param name="pool">目标池</param>
        /// <returns>自定义绘制图片</returns>
        Bitmap DrawAllItems(List<Image> allItemImages, List<GachaItem> gachaItems, Point[] drawPoints, Bitmap backgroundImg, Pool pool);
    }

    /// <summary>
    /// 自定义绘制子图片.
    /// 实现该接口后, 原本的自带默认绘制将失效
    /// </summary>
    public interface IDrawItem
    {
        /// <summary>
        /// 自定义重新绘制结果子图片
        /// </summary>
        /// <param name="item">描述需要绘制图片的对象</param>
        /// <param name="pool">目标池</param>
        /// <returns>自定义绘制图片</returns>
        Bitmap DrawPicItem(GachaItem item, Pool pool, Bitmap mainImage);
    }

    /// <summary>
    /// 自定义绘制子元素中心图片.
    /// 实现该接口后, 原本的自带默认绘制将失效
    /// </summary>
    public interface IDrawMainImage
    {
        /// <summary>
        /// 重新绘制抽卡子元素中的中心图片
        /// </summary>
        /// <param name="mainImage">未经处理的中心图片</param>
        /// <param name="pool">目标池</param>
        /// <returns>处理后的图片</returns>
        Bitmap RedrawMainImage(Bitmap mainImage, Pool pool, GachaItem item);
    }

    /// <summary>
    /// 自定义获取绘制坐标.
    /// 实现该接口后, 原本的自带默认坐标设置将失效
    /// </summary>
    public interface IDrawPoints
    {
        /// <summary>
        /// 获取绘制的坐标
        /// </summary>
        /// <returns>坐标数组</returns>
        Point[] GetDrawPoints(Pool pool, int count = 10);
    }

    /// <summary>
    /// 在所有基础绘制结束后，自定义对图片处理.
    /// </summary>
    public interface IFinallyDraw
    {
        /// <summary>
        /// 自定义对原图片重新绘制
        /// </summary>
        /// <param name="finPic">最终处理的图片</param>        
        /// <param name="drawPoints">绘制的坐标</param>
        /// <param name="gachaItems">图片对应的项目</param>
        /// <param name="user">调用者QQ</param>
        /// <param name="pool">目标池</param>
        /// <returns>自定义绘制图片</returns>
        Bitmap FinallyDraw(Bitmap finPic, Point[] drawPoints, List<GachaItem> gachaItems, User user, Pool pool);
    }
}
