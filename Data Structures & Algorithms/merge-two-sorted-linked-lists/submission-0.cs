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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var l1 = list1;
        var l2 = list2;
        var curr = new ListNode(0);
        var newHead = curr;
        while(l1 != null || l2 != null) {
            
            if(l1 == null || (l2 != null && l2.val < l1.val)) {
                curr.next = l2;
                l2 = l2.next;
            }
            else  {
                curr.next = l1;
                l1 = l1.next;
            }

            curr = curr.next;
        }

        return newHead.next;
        
    }
}