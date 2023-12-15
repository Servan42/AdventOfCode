using AdventOfCode2023.Core.Daily.Day15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    public class Day15Tests
    {
        Day15Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day15Ex();
        }

        [TestCase("rn=1", "30")]
        [TestCase("cm-", "253")]
        [TestCase("qp=3", "97")]
        [TestCase("cm=2", "47")]
        [TestCase("qp-", "14")]
        [TestCase("pc=4", "180")]
        [TestCase("ot=9", "9")]
        [TestCase("ab=5", "197")]
        [TestCase("pc-", "48")]
        [TestCase("pc=6", "214")]
        [TestCase("ot=7", "231")]
        public void Should_hash_single_step(string step, string expectedHash)
        {
            // Given
            sut.InputLines.Add(step);

            // When
            sut.ComputePart1();

            // Then
            Assert.That(sut.Output, Is.EqualTo(expectedHash));
        }

        [Test]
        public void Should_split_lines_by_comma_and_sum_the_hashs()
        {
            // Given
            sut.InputLines.Add("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7");

            // When
            sut.ComputePart1();

            // Then
            Assert.That(sut.Output, Is.EqualTo("1320"));
        }

        [Test]
        public void Should_remove_lens_from_box()
        {
            // Given
            sut.InputLines.Add("labelB-");
            int hash = sut.Hash("labelB");
            sut.Boxes.Add(hash, new List<string> { "labelA 5", "labelB 5", "labelC 5" });

            // When
            sut.ComputeBoxes();

            // Then
            CollectionAssert.AreEqual(new List<string> { "labelA 5", "labelC 5" }, sut.Boxes[hash]);
        }

        [Test]
        public void Should_do_nothing_when_asked_to_remove_a_lens_that_is_not_in_the_box()
        {
            // Given
            sut.InputLines.Add("labelB-");
            int hash = sut.Hash("labelB");
            sut.Boxes.Add(hash, new List<string> { "labelA 5", "labelC 5" });

            // When
            sut.ComputeBoxes();

            // Then
            CollectionAssert.AreEqual(new List<string> { "labelA 5", "labelC 5" }, sut.Boxes[hash]);
        }

        [Test]
        public void Should_do_nothing_when_asked_to_remove_a_lens_that_has_a_new_hash()
        {
            // Given
            sut.InputLines.Add("labelB-");
            int hash = sut.Hash("labelB");
            sut.Boxes.Add(hash + 1, new List<string> { "labelA 5", "labelB 5", "labelC 5" });

            // When
            sut.ComputeBoxes();

            // Then
            CollectionAssert.AreEqual(new List<string> { "labelA 5", "labelB 5", "labelC 5" }, sut.Boxes[hash + 1]);
        }

        [Test]
        public void Should_add_lens_to_box_when_already_present()
        {
            // Given
            sut.InputLines.Add("labelB=2");
            int hash = sut.Hash("labelB");
            sut.Boxes.Add(hash, new List<string> { "labelA 5", "labelB 5", "labelC 5" });

            // When
            sut.ComputeBoxes();

            // Then
            CollectionAssert.AreEqual(new List<string> { "labelA 5", "labelB 2", "labelC 5" }, sut.Boxes[hash]);
        }

        [Test]
        public void Should_add_lens_to_box_when_not_already_present()
        {
            // Given
            sut.InputLines.Add("labelB=2");
            int hash = sut.Hash("labelB");
            sut.Boxes.Add(hash, new List<string> { "labelA 5", "labelC 5" });

            // When
            sut.ComputeBoxes();

            // Then
            CollectionAssert.AreEqual(new List<string> { "labelA 5", "labelC 5", "labelB 2" }, sut.Boxes[hash]);
        }

        [Test]
        public void Should_have_example_box_state()
        {
            // Given
            sut.InputLines.Add("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7");
            
            // When
            sut.ComputeBoxes();
            
            // Then
            CollectionAssert.AreEqual(new List<string> { "rn 1", "cm 2" }, sut.Boxes[0]);
            CollectionAssert.AreEqual(new List<string>(), sut.Boxes[1]);
            CollectionAssert.AreEqual(new List<string> { "ot 7", "ab 5", "pc 6" }, sut.Boxes[3]);
        }

        [Test]
        public void Should_Calculate_focusing_power()
        {
            // Given
            sut.InputLines.Add("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7");

            // When
            sut.ComputePart2();

            // Then
            Assert.That(sut.Output, Is.EqualTo("145"));
        }
    }
}
