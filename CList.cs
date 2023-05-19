using System;

namespace _6th_LAB_OOP
{
    public abstract class CShape
    {
        protected bool is_selected;
        protected int length;
        protected int x, y;
        protected string color;
        protected int height, width;

        public CShape()
        {
            is_selected = false;
            length = 0;
            x = 0;
            y = 0;
            color = "";
        }

        public virtual void Select() { is_selected = true; }
        public virtual void Unselect() { is_selected = false; }
        public virtual bool IsSelected() { return is_selected; }
        public virtual void ChangeColor(string color) { this.color = color; }
        public virtual void Move(int dx, int dy) { if (canChange(dx, dy, 0)) { x += dx; y += dy; } }

        public abstract bool canChange(int dx, int dy, int dlength);
        public abstract void ChangeSize(char type);
        public abstract bool WasClicked(int x, int y);
        public abstract void Draw(Designer designer);
        public abstract void Save();
        public abstract void Load();
    }

    public class Node
    {
        public CShape shape;
        public Node next;

        public Node(CShape shape)
        {
            this.shape = shape;
            next = null;
        }
    }

    public class List
    {
        private Node head;
        private Node tail;
        private int count;

        public List()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Add(CShape shape)
        {
            Node newNode = new Node(shape);

            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }

            count++;
        }

        public void Remove(CShape shape)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.shape == shape)
                {
                    if (previous != null)
                    {
                        previous.next = current.next;

                        if (current == tail)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = current.next;

                        if (current == tail)
                        {
                            tail = null;
                        }
                    }

                    count--;
                    break;
                }

                previous = current;
                current = current.next;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            Node previous = null;

            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current.next;
            }

            if (previous != null)
            {
                previous.next = current.next;

                if (current == tail)
                {
                    tail = previous;
                }
            }
            else
            {
                head = current.next;

                if (current == tail)
                {
                    tail = null;
                }
            }

            count--;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public int GetSize()
        {
            return count;
        }

        public CShape Get(int index)
        {   
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = this.head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.shape;
                }

                currentIndex++;
                current = current.next;
            }

            return null;
        }
    }
}