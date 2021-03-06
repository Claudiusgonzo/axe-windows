// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Axe.Windows.Core.Enums;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvaluationCode = Axe.Windows.Rules.EvaluationCode;

namespace Axe.Windows.RulesTest.Library
{
    [TestClass]
    public class BoundingRectangleNotNullTest
    {
        private static Axe.Windows.Rules.IRule Rule = new Axe.Windows.Rules.Library.BoundingRectangleNotNull();

        [TestMethod]
        public void TestBoundingRectangleNotNullPass()
        {
            using (var e = new MockA11yElement())
            {
                e.BoundingRectangle = Rectangle.Empty;
                Assert.AreEqual(Rule.Evaluate(e), EvaluationCode.Pass);
            } // using
        }

        [TestMethod]
        public void TestBoundingRectangleNotNullFail()
        {
            using (var e = new MockA11yElement())
            {
                Assert.AreNotEqual(Rule.Evaluate(e), EvaluationCode.Pass);
            } // using
        }

        [TestMethod]
        public void BoundingRectangleNotNull_WPFScrollbarPageUpButton_NotApplicable()
        {
            using (var e = new MockA11yElement())
            using (var parent = new MockA11yElement())
            {
                parent.ControlTypeId = ControlType.ScrollBar;
                e.IsOffScreen = false;
                e.ControlTypeId = ControlType.Button;
                e.Framework = "WPF";
                e.AutomationId = "PageUp";
                parent.Children.Add(e);
                e.Parent = parent;

                Assert.IsFalse(Rule.Condition.Matches(e));
            } // using
        }

        [TestMethod]
        public void BoundingRectangleNotNull_WPFScrollbarPageDownButton_NotApplicable()
        {
            using (var e = new MockA11yElement())
            using (var parent = new MockA11yElement())
            {
                parent.ControlTypeId = ControlType.ScrollBar;
                e.IsOffScreen = false;
                e.ControlTypeId = ControlType.Button;
                e.Framework = "WPF";
                e.AutomationId = "PageDown";
                parent.Children.Add(e);
                e.Parent = parent;

                Assert.IsFalse(Rule.Condition.Matches(e));
            } // using
        }

        [TestMethod]
        public void BoundingRectangleNotNull_WPFScrollbarPageLeftButton_NotApplicable()
        {
            using (var e = new MockA11yElement())
            using (var parent = new MockA11yElement())
            {
                parent.ControlTypeId = ControlType.ScrollBar;
                e.IsOffScreen = false;
                e.ControlTypeId = ControlType.Button;
                e.Framework = "WPF";
                e.AutomationId = "PageLeft";
                parent.Children.Add(e);
                e.Parent = parent;

                Assert.IsFalse(Rule.Condition.Matches(e));
            } // using
        }

        [TestMethod]
        public void BoundingRectangleNotNull_NonFocusableSliderButton_NotApplicable()
        {
            using (var e = new MockA11yElement())
            using (var parent = new MockA11yElement())
            {
                parent.ControlTypeId = ControlType.Slider;
                e.IsKeyboardFocusable = false;
                e.ControlTypeId = ControlType.Button;
                parent.Children.Add(e);
                e.Parent = parent;

                Assert.IsFalse(Rule.Condition.Matches(e));
            } // using
        }

        [TestMethod]
        public void BoundingRectangleNotNull_EdgeGroup_NotApplicable()
        {
            using (var e = new MockA11yElement())
            using (var parent = new MockA11yElement())
            {
                parent.ControlTypeId = ControlType.Slider;
                e.Framework = Framework.Edge;
                e.ControlTypeId = ControlType.Group;
                parent.Children.Add(e);
                e.Parent = parent;

                Assert.IsFalse(Rule.Condition.Matches(e));
            } // using
        }

        [TestMethod]
        public void BoundingRectangleNotNull_SystemMenu_NotApplicable()
        {
            using (var e = new MockA11yElement())
            using (var parent = new MockA11yElement())
            {
                parent.ControlTypeId = ControlType.MenuBar;
                parent.AutomationId = "SystemMenuBar";
                e.ControlTypeId = ControlType.MenuItem;
                parent.Children.Add(e);
                e.Parent = parent;

                Assert.IsFalse(Rule.Condition.Matches(e));
            } // using
        }

        [TestMethod]
        public void BoundingRectangleNotNull_SystemMenuBar_NotApplicable()
        {
            using (var e = new MockA11yElement())
            {
                e.ControlTypeId = ControlType.MenuBar;
                e.AutomationId = "SystemMenuBar";

                Assert.IsFalse(Rule.Condition.Matches(e));
            } // using
        }
    } // class
} // namespace
