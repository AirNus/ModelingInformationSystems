using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelingInformationSystems
{
    class MyThread
    {
        internal string Name;
        internal Queue<int> pool;
        internal bool working;
        internal MyThread()
        {

        }
        internal MyThread(Queue<int> pool)
        {
            this.pool = pool;
            working = true;           
        }
    }
    class MyTask
    {
        internal string nameThread;
        internal string Name;
        internal int id;
        internal int MaxWorkTimer;
        internal bool ready;
        internal int totalTime;
        internal int timeFinish;
    }
    class CPUModel
    {
        static Random random = new Random();
        
        static internal Dictionary<string,int> ModellingWorkCPU(int timeDuration)
        {
            
            MyThread frstPool = new MyThread(new Queue<int>()) { Name = "first"};
            MyThread scndPool = new MyThread(new Queue<int>()) { Name = "second"};
            List<MyThread> threads = new List<MyThread>();
            threads.Add(frstPool);
            threads.Add(scndPool);

            MyTask Monitor = new MyTask() { Name = "Monitor",id = 2, MaxWorkTimer = 10, ready = true, totalTime = 0 };
            MyTask Calculation = new MyTask() { Name = "Calculation",id = 1, MaxWorkTimer = 10, ready = false, totalTime = 0 };
            MyTask Printer = new MyTask() { Name = "Printer", id = 3, MaxWorkTimer = 20, ready = true, totalTime = 0 };

            List<MyTask> tasks = new List<MyTask>();
            tasks.Add(Monitor);
            tasks.Add(Calculation);
            tasks.Add(Printer);
            
            for(int i = 0; i < threads.Count; i++)
            {
                threads[i].pool.Enqueue(1);
                tasks[1].timeFinish = tasks[1].MaxWorkTimer;
                tasks[1].totalTime = tasks[1].MaxWorkTimer;
            }
            for (int i = 0; i < timeDuration; i++)
            {
                foreach(MyThread thread in threads)
                {
                    foreach(MyTask task in tasks)
                    {
                        if (task.ready && !thread.working && task.id == thread.pool.First())
                        {
                            thread.working = true;
                            task.ready = false;
                            thread.pool.Dequeue();
                            int durationCurrentTask = random.Next(task.MaxWorkTimer);
                            task.totalTime += durationCurrentTask;
                            task.timeFinish = i + durationCurrentTask;
                            task.nameThread = thread.Name;
                        }
                        if(i == task.timeFinish && task.ready == false)
                        {
                            task.ready = true;
                            thread.working = false;
                            int incomingTask = random.Next(1,tasks.Count + 1);
                            thread.pool.Enqueue(incomingTask);
                        }    
                        if(task.id == thread.pool.First() && !task.ready && task.nameThread != thread.Name)
                        {
                            int deferredTask = thread.pool.Dequeue();
                            thread.pool.Enqueue(deferredTask);
                        }
                    }
                    
                }               
            }
            Dictionary<string, int> answer = new Dictionary<string, int>();
            int mainTotalTime = 0;
            foreach(MyTask task in tasks)
            {
                mainTotalTime += task.totalTime;
                answer.Add(task.Name, task.totalTime);
            }
            answer.Add("total", mainTotalTime);
            return answer;
        }
    }
}
