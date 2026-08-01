public class MedianFinder {

    PriorityQueue<int, int> minQ;
    PriorityQueue<int, int> maxQ ;

    public MedianFinder() {
        minQ = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        maxQ = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

    }
    
    public void AddNum(int num) {
        
        minQ.Enqueue(num, num);

        if(maxQ.Count + 1 < minQ.Count) {
            var element = minQ.Dequeue();
            maxQ.Enqueue(element, element);
        }
        
        if(maxQ.Count != 0 && minQ.Peek() < maxQ.Peek()) {
            var element = minQ.Dequeue();
            var element1 = maxQ.Dequeue();
            
            minQ.Enqueue(element1, element1);
            maxQ.Enqueue(element, element);
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
