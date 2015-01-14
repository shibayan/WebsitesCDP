using System;

using Microsoft.Azure.WebJobs;

namespace PipesAndFilters.WebJobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new JobHost();

            host.RunAndBlock();
        }

        public static void FirstStage([QueueTrigger("first")] string inbound, [Queue("second")] out string outbound)
        {
            // 何かする
            outbound = "first " + inbound;
        }

        public static void SecondStage([QueueTrigger("second")] string inbound, [Queue("third")] out string outbound)
        {
            // 何かする
            outbound = "second " + inbound;
        }

        public static void ThirdStage([QueueTrigger("third")] string inbound)
        {
            Console.WriteLine("third " + inbound);
        }
    }
}
