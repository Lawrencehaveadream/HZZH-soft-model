using System;
using System.Runtime.InteropServices;

namespace Common
{
    /// <summary>
    /// 两位浮点型数据
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class PointF2 
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    /// <summary>
    /// 三位浮点型数据
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class PointF3 
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
    /// <summary>
    /// 四位浮点型数据
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class PointF4
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float R { get; set; }
    }

    /// <summary>
    /// Combobox绑定显示类
    /// </summary>
    [Serializable]
    public class EffectiveMode
    {
        public int Index { get; set; }//有效值
        public string Name { get; set; }

        public EffectiveMode()
        {
            Index = 0;
            Name = "";
        }
    }


    /// <summary>
    /// 通信读写数据
    /// </summary>
    public class BaseData
    {
        public ushort Address { get; set; }
        public int[] IntValue { get; set; }
        public float[] FloatValue { get; set; }
        public ushort[] UshortValue { get; set; }
        public uint[] UintValue { get; set; }
        public short[] ShortValue { get; set; }
        public byte[] ByteValue { get; set; }
        public object ObjectValue { get; set; }
        public ushort RegisterNum { get; set; }
        public bool Succeed { get; set; }
        public DataType DataTypes { get; set; }
        public bool ReadHand { get; set; }//主动读取

         
        public BaseData()
        {
            Succeed = false;
        }

        /// <summary>
        /// 构造函数写整形
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="arrValue">数据</param>
        public BaseData(ushort address, int[] arrValue)
        {
            this.Address = address;
            this.IntValue = (int[])arrValue.Clone();
            this.DataTypes = DataType.Int;
            this.Succeed = false;
            this.ReadHand = false;
        }

        /// <summary>
        /// 构造函数写浮点型
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="arrValue">数据</param>
        public BaseData(ushort address, float[] arrValue)
        {
            this.Address = address;
            this.FloatValue = (float[])arrValue.Clone();
            this.DataTypes = DataType.Float;
            this.Succeed = false;
            this.ReadHand = false;
        }
        /// <summary>
        /// 构造函数写无符号短整型
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="arrValue">数据</param>
        public BaseData(ushort address, ushort[] arrValue)
        {
            this.Address = address;
            this.UshortValue = (ushort[])arrValue.Clone();
            this.DataTypes = DataType.Ushort;
            this.Succeed = false;
            this.ReadHand = false;
        }
        /// <summary>
        /// 构造函数写短整型
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="arrValue">数据</param>
        public BaseData(ushort address, short[] arrValue)
        {
            this.Address = address;
            this.ShortValue = (short[])arrValue.Clone();
            this.DataTypes = DataType.Short;
            this.Succeed = false;
            this.ReadHand = false;
        }
        /// <summary>
        /// 构造函数写无符号整型
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="arrValue">数据</param>
        public BaseData(ushort address, uint[] arrValue)
        {
            this.Address = address;
            this.UintValue = (uint[])arrValue.Clone();
            this.DataTypes = DataType.Uint;
            this.Succeed = false;
            this.ReadHand = false;
        }
        /// <summary>
        /// 构造函数写字节
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="arrValue">数据</param>
        public BaseData(ushort address, byte[] arrValue)
        {
            this.Address = address;
            this.ByteValue = (byte[])arrValue.Clone();
            this.DataTypes = DataType.Byte;
            this.Succeed = false;
            this.ReadHand = false;
        }
        /// <summary>
        /// 构造函数写对象
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="arrValue">数据</param>
        public BaseData(ushort address, object objectValue)
        {
            this.Address = address;
            this.ObjectValue = objectValue;
            this.DataTypes = DataType.Object;
            this.Succeed = false;
            this.ReadHand = false;
        }

        /// <summary>
        /// 构造函数读取数据
        /// </summary>
        /// <param name="addr">地址</param>
        /// <param name="numbers">数量</param>
        /// <param name="dt">读取的数据类型</param>
        public BaseData(ushort addr, int numbers, DataType dt = DataType.Int)
        {
            this.Address = addr;
            this.RegisterNum = (ushort)numbers;
            switch (dt)
            {
                case DataType.Int:
                    this.IntValue = new int[numbers];
                    break;
                case DataType.Float:
                    this.FloatValue = new float[numbers];
                    break;
                case DataType.Uint:
                    this.UintValue = new uint[numbers];
                    break;
                case DataType.Ushort:
                    this.UshortValue = new ushort[numbers];
                    break;
                case DataType.Short:
                    this.ShortValue = new short[numbers];
                    break;
                case DataType.Byte:
                    this.ByteValue = new byte[numbers * 2];
                    break;
                default:
                    break;
            }
            this.DataTypes = dt;
            this.Succeed = false;
            this.ReadHand = true;
        }

    }
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataType
    {
        Int,
        Float,
        Ushort,
        Short,
        Uint,
        Byte,
        Object
    }





}
