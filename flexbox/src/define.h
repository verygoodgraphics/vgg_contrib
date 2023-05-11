﻿/*
MIT License

Copyright (c) 2023 Very Good Graphics

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

#ifndef VGG_FLEXBOX_DEFINE
#define VGG_FLEXBOX_DEFINE

enum direction
{
    direction_row = 0,
    direction_column
};

enum justify_content
{
    justify_content_flex_start = 0,
    justify_content_center,
    justify_content_flex_end,
    justify_content_space_between,
    justify_content_space_around,
    justify_content_space_evenly
};

enum align_items
{
    align_items_flex_start = 0,
    align_items_center,
    align_items_flex_end
};

enum align_content
{
    align_content_flex_start = 0,
    align_content_center,
    align_content_flex_end
};

enum wrap
{
    wrap_wrap = 0,
    wrap_no_wrap
};

enum gap
{
    gap_column = 0,
    gap_row,
    //gap_all
};

enum padding
{
    padding_left = 0,
    padding_top,
    padding_right,
    padding_bottom
};

enum position
{
    position_absolute = 0,

    //szn_todo 
    //position_sticky,
    //position_fixed,

    position_relative,
};

enum ltrb
{
    ltrb_left = 0,
    ltrb_top,
    ltrb_right,
    ltrb_bottom
};

enum overflow
{
    overflow_visible = 0,
    overflow_hidden,
    overflow_scroll
};

enum unit
{
    unit_point,
    unit_percent,   // 50 for 50%
    unit_auto,
    unit_undefine
};

#endif