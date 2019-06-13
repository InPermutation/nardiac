﻿using System;

namespace NARDIAC
{
    public enum Opcode : byte
    {
        INP = 0,
        CLA = 1,
        ADD = 2,
        TAC = 3,
        SFT = 4,
        OUT = 5,
        STO = 6,
        SUB = 7,
        JMP = 8,
        HRS = 9,
    }

    public class Computer
    {
        bool paused = true;
        int pc = 0;
        Cell ir; // Instruction register
        Cell a = new Cell(0, 0, 0); // Accumulator register
        byte carry = 0; // Accumulator's carry

        Opcode op => (Opcode)ir.Item1;
        int xy => ir.Item2 * 10 + ir.Item3;

        readonly NARDIAC.Input input;
        readonly NARDIAC.Output output;
        readonly NARDIAC.Memory memory = new Memory();

        public Computer(Input input, Output output)
        {
            if (input == null) throw new ArgumentNullException("input");
            if (output == null) throw new ArgumentNullException("output");
            this.input = input;
            this.output = output;
        }

        public void Run()
        {
            paused = false;
            while (!paused)
            {
                Step();
            }
        }

        private void Step()
        {
            ir = memory[pc];
            pc++;

            switch (op)
            {
                case Opcode.INP: // 0XY INP - Read input card into cell XY
                    Inp();
                    break;
                case Opcode.CLA: // 1XY CLA - Clear accumulator and add into it the contents of cell XY
                    Cla();
                    break;
                case Opcode.ADD: // 2XY ADD - Add contents of cell XY into accumulator.
                    Add();
                    break;
                case Opcode.TAC: // 3XY TAC - Test accumulator and jump if negative.
                    Tac();
                    break;
                case Opcode.SFT: // 4XY SFT - Shift accumulator X left, then Y right
                    Sft();
                    break;
                case Opcode.OUT: // 5XY OUT - Print contents of cell XY on output card
                    Out();
                    break;
                case Opcode.STO: // 6XY STO - Store contents of accumulator in cell XY.
                    Sto();
                    break;
                case Opcode.SUB: // 2XY SUB - Subtract contents of cell XY from accumulator.
                    Sub();
                    break;
                case Opcode.JMP: // 8XY JMP - Jump to XY and save PC to *99
                    Jmp();
                    break;
                case Opcode.HRS: // 9XY HRS - Halt and reset program counter to XY. (usually 900)
                    Hrs();
                    break;

                default:
                    throw new NotImplementedException(ir.Item1.ToString());
            }
        }

        private void Inp()
        {
            memory[xy] = input.Read();
        }

        private void Cla()
        {
            a = memory[xy];
        }

        private void Add()
        {
            int @int = IntFromCell(a) + IntFromCell(memory[xy]);
            a = CellFromInt(@int);
            if (@int < 0) @int = -@int;
            carry = (byte)(@int / 1000);
        }

        private void Sft() => throw new NotImplementedException("SFT");

        private void Tac()
        {
            if (a.Negative)
            {
                // do not save old pc to *99
                pc = xy;
            }
        }

        private void Out()
        {
            output.Write(memory[xy]);
        }

        private void Sto()
        {
            memory[xy] = a;
        }

        private void Sub()
        {
            int @int = IntFromCell(a) - IntFromCell(memory[xy]);
            a = CellFromInt(@int);
            if (@int < 0) @int = -@int;
            carry = (byte)(@int / 1000);
        }

        private void Jmp()
        {
            memory[99] = CellFromInt((pc % 100) + 800);
            pc = xy;
        }

        private void Hrs()
        {
            pc = xy;
            paused = true;
        }

        private Cell CellFromInt(int i)
        {
            bool neg = i < 0;
            if (neg) i = -i;
            return new Cell(
                (byte)(i / 100),
                (byte)((i % 100) / 10),
                (byte)(i % 10),
                neg
                );
        }

        private int IntFromCell(Cell c)
        {
            var i = c.Item1 * 100 + c.Item2 * 10 + c.Item3;
            return c.Negative ? -i : i;
        }
    }
}
