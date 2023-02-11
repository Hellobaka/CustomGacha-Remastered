using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GachaCore.Model
{
    /// <summary>
    /// 池子内全局图片绘制设置，间隔不包括图片大小
    /// </summary>
    public class PoolDrawConfig
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// 绘制的起点坐标
        /// </summary>
        public int StartPointX { get; set; }
        public int StartPointY { get; set; }
        /// <summary>
        /// 每个项目之间的X坐标间隔
        /// </summary>
        public int DrawXInterval { get; set; }
        /// <summary>
        /// 每个项目之间的Y坐标间隔
        /// </summary>
        public int DrawYInterval { get; set; }
        /// <summary>
        /// 大于等于此值将会换行
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// 换行之后Y坐标变化值，请不考虑图片大小
        /// </summary>
        public int YChange { get; set; }
        /// <summary>
        /// 换行之后X坐标变化值
        /// </summary>
        public int XChange { get; set; }
        /// <summary>
        /// 抽卡结束之后按价值的排序方式
        /// </summary>
        public OrderOptional OrderOptional { get; set; }
      
        public PoolDrawConfig Clone()
        {
            return new PoolDrawConfig
            {
                StartPointX = StartPointX,
                StartPointY = StartPointY,
                DrawXInterval = DrawXInterval,
                DrawYInterval = DrawYInterval,
                MaxX = MaxX,
                YChange= YChange,
                XChange = XChange,
                OrderOptional = OrderOptional
            };
        }
    }

    public class ItemDrawConfig
    {
        /// <summary>
        /// 核心图片绘制大小
        /// </summary>
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        /// <summary>
        /// 背景图片绘制大小
        /// </summary>
        public int BackgroundImageWidth { get; set; }
        public int BackgroundImageHeight { get; set; }
        /// <summary>
        /// 背景与核心图片绘制顺序
        /// </summary>
        public DrawOrder DrawOrder { get; set; }
        /// <summary>
        /// 核心图片相对于背景的偏移坐标
        /// </summary>
        public int ImagePointX { get; set; }
        public int ImagePointY { get; set; }

        public ItemDrawConfig Clone()
        {
            return new ItemDrawConfig
            {
                ImageWidth = ImageWidth,
                ImageHeight = ImageHeight,
                BackgroundImageWidth = BackgroundImageWidth,
                BackgroundImageHeight = BackgroundImageHeight,
                DrawOrder = DrawOrder,
                ImagePointX = ImagePointX,
                ImagePointY = ImagePointY,
            };
        }
    }
    /// <summary>
    /// 排序方式
    /// </summary>
    public enum OrderOptional
    {
        /// <summary>
        /// 升序，从小到大
        /// </summary>
        Increasing,
        /// <summary>
        /// 降序，从大到小
        /// </summary>
        Descending,
        /// <summary>
        /// 不排序
        /// </summary>
        None
    }
    public enum DrawOrder
    {
        /// <summary>
        /// 绘制时，核心图片晚于背景绘制，核心图片非透明部分可能会覆盖部分背景
        /// </summary>
        ImageAboveBackground,
        /// <summary>
        /// 绘制时，背景晚于核心图片绘制，背景非透明部分可能会覆盖部分核心图片
        /// </summary>
        ImageBelowBackground
    }
}
