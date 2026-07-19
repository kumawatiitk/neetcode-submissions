/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {    
    public ListNode MergeKLists(ListNode[] lists) {
        var pq = new PriorityQueue<ListNode, int>();
        foreach(var node in lists) {
            if(node != null) {
                pq.Enqueue(node, node.val);
            }
        }

        ListNode res = null;
        ListNode end = null;
        while(pq.Count != 0) {
            var curr = pq.Dequeue();
            if(curr.next != null) {
                pq.Enqueue(curr.next, curr.next.val);
            }

            if(res == null) {
                res = curr;
                end = curr;
            } else {
                end.next = curr;
                end = end.next;
            }

            curr = curr.next;
            end.next = null;
        }

        return res;
    }
}
