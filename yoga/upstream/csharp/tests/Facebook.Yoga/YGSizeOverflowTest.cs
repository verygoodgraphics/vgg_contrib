/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */

// @generated by gentest/gentest.rb from gentest/fixtures/YGSizeOverflowTest.html

using System;
using NUnit.Framework;

namespace Facebook.Yoga
{
    [TestFixture]
    public class YGSizeOverflowTest
    {
        [Test]
        public void Test_nested_overflowing_child()
        {
            YogaConfig config = new YogaConfig();
            config.SetExperimentalFeatureEnabled(YogaExperimentalFeature.AbsolutePercentageAgainstPaddingEdge, true);
            config.SetExperimentalFeatureEnabled(YogaExperimentalFeature.FixAbsoluteTrailingColumnMargin, true);

            YogaNode root = new YogaNode(config);
            root.Width = 100;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode(config);
            root.Insert(0, root_child0);

            YogaNode root_child0_child0 = new YogaNode(config);
            root_child0_child0.Width = 200;
            root_child0_child0.Height = 200;
            root_child0.Insert(0, root_child0_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(200f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0.LayoutHeight);

            Assert.AreEqual(-100f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(200f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0_child0.LayoutHeight);
        }

        [Test]
        public void Test_nested_overflowing_child_in_constraint_parent()
        {
            YogaConfig config = new YogaConfig();
            config.SetExperimentalFeatureEnabled(YogaExperimentalFeature.AbsolutePercentageAgainstPaddingEdge, true);
            config.SetExperimentalFeatureEnabled(YogaExperimentalFeature.FixAbsoluteTrailingColumnMargin, true);

            YogaNode root = new YogaNode(config);
            root.Width = 100;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode(config);
            root_child0.Width = 100;
            root_child0.Height = 100;
            root.Insert(0, root_child0);

            YogaNode root_child0_child0 = new YogaNode(config);
            root_child0_child0.Width = 200;
            root_child0_child0.Height = 200;
            root_child0.Insert(0, root_child0_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(200f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(100f, root_child0.LayoutHeight);

            Assert.AreEqual(-100f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(200f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0_child0.LayoutHeight);
        }

        [Test]
        public void Test_parent_wrap_child_size_overflowing_parent()
        {
            YogaConfig config = new YogaConfig();
            config.SetExperimentalFeatureEnabled(YogaExperimentalFeature.AbsolutePercentageAgainstPaddingEdge, true);
            config.SetExperimentalFeatureEnabled(YogaExperimentalFeature.FixAbsoluteTrailingColumnMargin, true);

            YogaNode root = new YogaNode(config);
            root.Width = 100;
            root.Height = 100;

            YogaNode root_child0 = new YogaNode(config);
            root_child0.Width = 100;
            root.Insert(0, root_child0);

            YogaNode root_child0_child0 = new YogaNode(config);
            root_child0_child0.Width = 100;
            root_child0_child0.Height = 200;
            root_child0.Insert(0, root_child0_child0);
            root.StyleDirection = YogaDirection.LTR;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(100f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0_child0.LayoutHeight);

            root.StyleDirection = YogaDirection.RTL;
            root.CalculateLayout();

            Assert.AreEqual(0f, root.LayoutX);
            Assert.AreEqual(0f, root.LayoutY);
            Assert.AreEqual(100f, root.LayoutWidth);
            Assert.AreEqual(100f, root.LayoutHeight);

            Assert.AreEqual(0f, root_child0.LayoutX);
            Assert.AreEqual(0f, root_child0.LayoutY);
            Assert.AreEqual(100f, root_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0.LayoutHeight);

            Assert.AreEqual(0f, root_child0_child0.LayoutX);
            Assert.AreEqual(0f, root_child0_child0.LayoutY);
            Assert.AreEqual(100f, root_child0_child0.LayoutWidth);
            Assert.AreEqual(200f, root_child0_child0.LayoutHeight);
        }

    }
}
