using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ByMarin
{
    class Thread
    {
        internal Queue<int> thread;
        internal bool working;
        internal Thread()
        {

        }
        internal Thread(Queue<int> thread)
        {
            this.thread = thread;
            working = false;           
        }
    }
    class CPUModel
    {
        static Random random = new Random();
        const int countTask = 3;
        const int calculationTask = 1;
        const int MaxWorkTimeCalculation = 5;


        const int printerTask = 2;
        const int MaxWorkTimePrinter = 20;

        const int monitorTask = 3;
        const int MaxWorkTimeMonitor = 10;
        static internal void ModellingWorkCPU(int timeDuration)
        {
            
            Thread firstThread = new Thread(new Queue<int>());
            Thread secondThread = new Thread(new Queue<int>());

            firstThread.thread.Enqueue(calculationTask);
            secondThread.thread.Enqueue(calculationTask);

            bool PrinterReady = true;
            int timePrinter = 0;
            int printerAvailable = 0;

            bool MonitorReady = true;
            int timeMonitor = 0;
            int monitorAvailable = 0;

            bool CalculationReady = true;                        
            int timeCalculation = 0;
            int calculationAvailable = 0;
               
            for(int i = 0; i < timeDuration; i++)
            {
                
            }
        }
    }
}
