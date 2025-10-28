MyStack<T>
Commonly used for undo/redo functionality.
A stack is a "Last-In-First-Out" (LIFO) data structure.
The most recently added item is always the first one to be removed.

Public Methods / Properties:

void Push(T item
Adds an item to the top of the stack	
Amortized O(1)

T Pop()	
Removes and returns the item at the top
throws InvalidOperationException if empty	
O(1)

T Peek()
Returns the item at the top without removing it
throws InvalidOperationException if empty
O(1)

int Count	
Number of items currently in the stack	
O(1)

Notes:
Uses a resizable array with doubling when full and optional shrinking when quarter full.
Provides amortized O(1) Push due to resizing.

MyQueue<T>
Commonly used for task scheduling.
A queue is a "First-In-First-Out" (FIFO) data structure.
Items are removed in the same order they were added.

Public Methods / Properties:

void Enqueue(T item)	
Adds an item to the end of the queue	
Amortized O(1)

T Dequeue()	
Removes and returns the item at the front
throws InvalidOperationException if empty	
Amortized O(1)

T Peek()	
Returns the item at the front without removing it
throws InvalidOperationException if empty
O(1)

int Count	
Number of items currently in the queue	
O(1)

Notes:
Uses a circular array with head/tail indices and modulo arithmetic.
Array doubles in size when full and halves when one quarter full.