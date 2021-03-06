using Array;

namespace StackAndQueues
{
    /// <summary>
    /// 基于前面实现的动态数组 来实现栈结构
    /// 注意：跨 project 调用 Array 类，需要在 csproj 中添加引用，本项目已添加引用
    /// </summary>
    public class ArrayStack<T> : IStack<T>
    {
        private Array<T> arr;

        public ArrayStack(int capacity)
        {
            arr = new Array<T>(capacity);
        }

        public ArrayStack() : this(10)
        {
        }

        public int GetSize()
        {
            return arr.GetSize();
        }

        public bool IsEmpty()
        {
            return arr.IsEmpty();
        }

        public void Push(T element)
        {
            arr.AddLast(element);
        }

        public T Pop()
        {
            return arr.RemoveLast();
        }

        public T Peek()
        {
            return arr.GetLast();
        }

        /// <summary>
        /// 获取栈的容量
        /// </summary>
        public int GetCapacity()
        {
            return arr.GetCapacity();
        }

        public override string ToString()
        {
            return $"ArrayStack: {arr}";
        }
    }
}