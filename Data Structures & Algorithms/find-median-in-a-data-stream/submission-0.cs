public class MedianFinder {

    PriorityQueue<int, int> minQ;
    PriorityQueue<int, int> maxQ ;

    public MedianFinder() {
        minQ = new PriorityQueue<int, int>();
        maxQ = new PriorityQueue<int, int>();

    }
    
    public void AddNum(int num) {
        
        minQ.Enqueue(num, num);

        if(maxQ.Count + 1 < minQ.Count) {
            var element = minQ.Dequeue();
            maxQ.Enqueue(element, element * -1);
        }
        
        if(maxQ.Count != 0 && minQ.Peek() < maxQ.Peek()) {
            var element = minQ.Dequeue();
            var element1 = maxQ.Dequeue();
            
            minQ.Enqueue(element1, element1);
            maxQ.Enqueue(element, element * -1);
        }
    }
    
    public double FindMedian() {
        if(minQ.Count == 0) return 0;
        if(minQ.Count == maxQ.Count) {
            return (minQ.Peek() + maxQ.Peek())/2.0;
        } else {
            return minQ.Peek();
        }
    }
}
