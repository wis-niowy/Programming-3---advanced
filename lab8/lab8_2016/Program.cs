using System;
using System.Collections;

namespace Lab8b
{
static class Program
    {
        public static void Main(string[] args)
            {
            Console.Out.WriteLine("Etap1:");
            IEnumerable seq1 = new int[] { 1, 2, 3, 4 };
            IEnumerable seq2 = Sequences.NaturalNumbers();
            IEnumerable seq3 = Sequences.LimitSequence(seq1, 1);
            IEnumerable seq4 = Sequences.LimitSequence(seq2, 5);

            Sequences.PrintSeq(seq1);
            Sequences.PrintSeq(seq3);
            Sequences.PrintSeq(seq3);
            Sequences.PrintSeq(seq4);
            Sequences.PrintSeq(seq4);

            Console.Out.WriteLine("Intersperse");
            IEnumerable seq21 = Sequences.Intersperse(seq1, 0);
            IEnumerable seq22 = Sequences.Intersperse(seq2, -1);
            Sequences.PrintSeq(seq21);
            Sequences.PrintSeq(seq21);

            Console.Out.WriteLine("\nEtap2:");
            Sequences.PrintSeq(Sequences.LimitSequence(seq22, 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.Cycle(seq1), 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.Cycle(seq2), 20));

            Console.Out.WriteLine("IndexOfFirstOccurrence");
            Console.Out.WriteLine("{0}", Sequences.IndexOfFirstOccurrence(seq1, 3));
            Console.Out.WriteLine("{0}", Sequences.IndexOfFirstOccurrence(seq2, 50));
            Console.Out.WriteLine("{0}", Sequences.IndexOfFirstOccurrence(seq1, 21));
            IEnumerable seq31 = Sequences.SkipN(seq1, 2);
            Sequences.PrintSeq(seq31);
            Sequences.PrintSeq(seq31);
            Console.Out.Write("Pusty ciąg: ");
            Sequences.PrintSeq(Sequences.SkipN(seq1, 25));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.SkipN(seq2, 5), 10));

            Console.Out.WriteLine("\nEtap3:");
            IEnumerable seq5 = new int[] { 3, 4, 5, 5 };
            Sequences.PrintSeq(Sequences.SequenceSum(seq1, seq5));
            Sequences.PrintSeq(Sequences.SequenceSum(seq2, seq5));
            Sequences.PrintSeq(Sequences.SequenceSum(seq1, seq2));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.SequenceSum(seq1,seq1),10));

            Console.Out.WriteLine("ArithmeticSubsequence");
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.ArithmeticSubsequence(seq1), 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.ArithmeticSubsequence(new int[] { 1, 3, 4, 5, 5, 5, 5, 5, 8, 7, 2, 1, 3, 5 }), 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.ArithmeticSubsequence(new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }), 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.ArithmeticSubsequence(new int[] { 1, 0, 4, 5, 5, 5, 5, 5, 8, 7, 2, 1, 3, -1 }), 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.ArithmeticSubsequence(seq2), 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.ArithmeticSubsequence(new int[] { }), 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.ArithmeticSubsequence(new int[] { 1 }), 20));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.ArithmeticSubsequence(new int[] { 1, 1 }), 20));

            Console.Out.WriteLine("\nEtap4:");
            IEnumerable seq6 = new int[] { 3, 4, 5, 5, 7, 8 };
            Sequences.PrintSeq(Sequences.SequenceSumWithTail(seq1, seq6));
            Sequences.PrintSeq(Sequences.SequenceSumWithTail(seq6, seq1));
            Sequences.PrintSeq(Sequences.SequenceSumWithTail(seq6, seq6));
            Sequences.PrintSeq(Sequences.LimitSequence(Sequences.SequenceSumWithTail(seq2, seq5), 10));

            Console.Out.WriteLine("\nEtap5:");
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18 }, new int[] { 1, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18 }, new int[] { 1, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 0 }, new int[] { 1, 1 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { }, new int[] { 1, 1 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { -3, -3, -3, -3, -3, -3, -3, -3 }, new int[] { -3 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 1, 1 }, new int[] { -3 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, -2, 7, 0, 13, -18, 27 }, new int[] { 2, -2, 1, 0, 0 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 0, 1, -2, 7, 0, 13, -18, 27 }, new int[] { 2, -2, 1, 0, 0 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, -2, 7, 0, 13, 18, 27 }, new int[] { 2, -2, 1, 0, 0 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, -2, 7, 0, 13, -18, 26 }, new int[] { 2, -2, 1, 0, 0 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, new int[] { 0, 0, 0, 0, 0 }));
        }
    }
}
