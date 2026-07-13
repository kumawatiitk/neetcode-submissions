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
    public void ReorderList(ListNode head) {

        if(head == null) return;

        ListNode prev = null;
        var fast = head.next;
        var slow = head;
        while(fast != null) {
            fast = fast.next;
            slow = slow.next;
            if(fast != null) {
                fast = fast.next;
            }
        }

        var curr =  slow.next;
        prev = null;
        while(curr != null) {
            var temp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = temp;
        }

        var r = prev;
        var l = head;
        slow.next = null;

        while(r != null)  {
            var nextl = l.next;
            var nextr = r.next;
            l.next = r;
            r.next = nextl;
            l = nextl;
            r = nextr;

        }
    }
}
