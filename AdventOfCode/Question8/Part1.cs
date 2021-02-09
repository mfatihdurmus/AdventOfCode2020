using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Question8
{
    public class Part1 : IQuestion
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

        public void Solve()
        {
            var input = File.ReadAllLines("./Question8/input.txt");
            List<Instruction> instructions = new List<Instruction>();

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

            int accumulator = 0;

            for (int i = 0; i < instructions.Count; i++)
            {
                var item = instructions[i];

                if (item.isExecuted == true)
                {
                    Console.WriteLine(accumulator);
                    break;
                }
                else
                {
                    item.isExecuted = true;
                }

                if (item.OpCode == OpType.NOP)
                {
                    continue;
                }
                else if(item.OpCode == OpType.ACC)
                {
                    accumulator += item.Parameter;
                }
                else
                {
                    i += item.Parameter - 1;
                }

            }

        }
    }
}
