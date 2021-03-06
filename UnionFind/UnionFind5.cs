using System;

namespace UnionFind
{
    /// <summary>
    /// UnionFind5 对 UnionFind4 进行了路径压缩的优化，从而减少树的高度
    /// 查找 O(h) 近乎 O(1)  合并 O(h)   h 为树的高度
    /// </summary>
    public class UnionFind5 : IUnionFind
    {
        /// <summary>
        /// parent[i] 表示第 i 个元素所指向的父节点
        /// </summary>
        private int[] parent;

        /// <summary>
        /// 表示以 i 为根的集合所表示的树的层数
        /// </summary>
        private int[] rank;

        public UnionFind5(int size)
        {
            parent = new int[size];
            rank = new int[size];

            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        public int GetSize()
        {
            return parent.Length;
        }

        /// <summary>
        /// 查找过程, 查找元素 p 所对应的集合编号。O(h)，h 为树的高度
        /// </summary>
        private int Find(int p)
        {
            if (p < 0 || p >= parent.Length)
                throw new ArgumentException("p is out of bound.");

            // 不断去查询自己的父亲节点, 直到到达根节点
            // 根节点的特点: parent[p] == p
            while (p != parent[p])
            {
                // 路径压缩
                parent[p] = parent[parent[p]];
                p = parent[p];
            }

            return p;
        }

        /// <summary>
        /// 查看元素 p 和元素 q 是否所属一个集合。O(h)，近乎 O(1)  h 为树的高度
        /// </summary>
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// 合并元素 p 和元素 q 所属的集合。O(h)，h 为树的高度
        /// </summary>
        public void UnionElements(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);

            if (pRoot == qRoot)
                return;

            // 将 rank 低的集合合并到 rank 高的集合上
            if (rank[pRoot] < rank[qRoot])
                parent[pRoot] = qRoot;
            else if (rank[qRoot] < rank[pRoot])
                parent[qRoot] = pRoot;
            else
            {
                // rank[pRoot] == rank[qRoot]
                parent[pRoot] = qRoot;
                rank[qRoot] += 1;
            }
        }
    }
}