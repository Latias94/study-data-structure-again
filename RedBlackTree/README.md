# 红黑树

## 添加新元素

一共三种情况：

![](https://i.loli.net/2019/04/06/5ca8981f33fcd.png)

## 性能总结

性能不太占优的三个原因：
1. 测试用例较小，更简单的算法，操作更少，可能更快。
2. 这里大多是查询操作 get & contain，因为红黑树本身不是一个严格的平衡树，高度最多可以达到 2*logn。如果结合添加删除查询三个操作，整体红黑树会占优。
3. 这里实现的红黑树还有优化的余地。

对于完全随机的数据，普通的二分搜索树很好用  
缺点：极端情况会退化成链表（或者高度不平衡）

对于查询较多的情况，AVL 树很好用

红黑树牺牲了平衡性  
**统计性能**更优（综合增删改查所有的操作）  
另一种统计性能更优的树结构是 Splay Tree （伸展树）  
局部性原理：刚被访问的内容下次高概率被再次访问

Java TreeMap TreeSet 底层都是红黑树  

其他红黑树的实现可以参考《算法导论》