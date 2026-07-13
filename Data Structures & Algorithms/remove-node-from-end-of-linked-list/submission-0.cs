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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        
        var fast = head;
        for(int i = 1; i <= n - 1; i++) {
            fast = fast.next;
            if(fast == null) {
                return head;
            }
        }
        fast = fast.next;
        
        var slow = head;
        ListNode prev = null;
        while(fast != null) {
            prev = slow;
            slow = slow.next;
            fast = fast.next;
        }

        if(prev == null) {
            return head.next;
        } else {
            prev.next = slow.next;
            return head;
        }
    }
}
