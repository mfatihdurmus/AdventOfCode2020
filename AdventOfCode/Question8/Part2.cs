using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Question8
{
    class Instruction
    {
        public OpType OpCode { get; set; }
        public int Parameter { get; set; }
        public bool isExecuted { get; set; }
    }

    enum OpType
    {
        NOP,
        ACC,
        JMP
    }

    public class Part2 : IQuestion
    {

        public void Solve()
        {
            var input = File.ReadAllLines("./Question8/input.txt");
            List<Instruction> instructions = new List<Instruction>();

            int lineNumber = 0;
            foreach (var line in input)
            {
                string operation = line.Substring(0, 3);
                OpType currentOp = OpType.NOP;

                if (operation == "acc")
                    currentOp = OpType.ACC;
                else if (operation == "jmp")
                    currentOp = OpType.JMP;
                else
                    currentOp = OpType.NOP;

                string parameter = line.Substring(3, line.Length - 3);
                int parameterValue = Int32.Parse(parameter);

                Instruction instruction = new Instruction();
                instruction.OpCode = currentOp;
                instruction.Parameter = parameterValue;
                instruction.isExecuted = false;
                instructions.Add(instruction);
            }

            foreach (var item in instructions)
            {
                if(item.OpCode == OpType.JMP)
                {
                    item.OpCode = OpType.NOP;
                    instructions.ForEach(x => x.isExecuted = false);

                    if (InfiniteLoopExists(instructions))
                    {
                        item.OpCode = OpType.JMP;
                    }
                    else
                    {
                        Console.WriteLine(FindAccumulator(instructions));
                        break;
                    }
                }
            }
        }

        private bool InfiniteLoopExists(List<Instruction> instructions)
        {
            int accumulator = 0;
            for (int i = 0; i < instructions.Count; i++)
            {
                var item = instructions[i];
                if (item.isExecuted)
                {
                    return true;
                }

                item.isExecuted = true;

                if (item.OpCode == OpType.NOP)
                {
                    continue;
                }

                else if (item.OpCode == OpType.ACC)
                {
                    accumulator += item.Parameter;
                }

                else if (item.OpCode == OpType.JMP)
                {
                    i += item.Parameter - 1;
                }
            }
            return false;
        }


        private int FindAccumulator(List<Instruction> instructions)
        {
            int accumulator = 0;
            for (int i = 0; i < instructions.Count; i++)
            {
                var item = instructions[i];
                if (item.OpCode == OpType.NOP)
                {
                    continue;
                }

                else if (item.OpCode == OpType.ACC)
                {
                    accumulator += item.Parameter;
                }

                else if (item.OpCode == OpType.JMP)
                {
                    i += item.Parameter - 1;
                }
            }
            return accumulator;
        }
    }
}
