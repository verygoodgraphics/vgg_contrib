# 3.24 for find_package GLOBAL keyword
cmake_minimum_required(VERSION 3.24)

project(vgg_contrib_nanobind)

find_package(Python 3.8 COMPONENTS Interpreter Development.Module REQUIRED GLOBAL)

add_subdirectory(upstream)