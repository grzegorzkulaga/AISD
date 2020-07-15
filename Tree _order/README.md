Description
A tree is a connected acyclic graph. A binary tree is a tree for which each node has a left child, a right child, both, or neither, e.g.

1
/ \
2 3
/ \ \
4 5 6
There are three common ways to recursively traverse such a tree.

Preorder: parent, left subtree, right subtree
Postorder: left subtree, right subtree, parent
Inorder: left subtree, parent, right subtree Given preorder, postorder, and inorder traversals, determine if they can be of the same binary tree. For example,
1 2 4 5 3 6
4 5 2 6 3 1
4 2 5 1 3 6
are the preorder, postorder, and inorder traversals of the tree above. But

1 2 4 5 3 6
4 5 2 6 1 3
4 2 5 1 6 3
cannot be the preorder, postorder, and inorder tranversals of the same binary tree.

Input
The first line is the number of nodes in each traversal, 0 < N <= 8000. The second line is the N space seperated nodes of the preorder traveral. The third line is the N space separated nodes of the postorder traversal. The fourth line is the N space separated nodes of the inorder traversal. Each traversal is a sequence of the nodes, numbered 1 to N, without repitition.

Output
Print "yes" if all three traversals can be of the same tree, and "no" otherwise.

Example
Input

6
1 2 4 5 3 6
4 5 2 6 3 1
4 2 5 1 3 6
Output

yes