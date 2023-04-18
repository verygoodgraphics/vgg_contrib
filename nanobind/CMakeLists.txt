cmake_minimum_required(VERSION 3.18...3.22)

project(vgg_contrib_nanobind)

find_package(Python 3.8 COMPONENTS Interpreter Development.Module REQUIRED)

add_subdirectory(upstream)

set(VGG_CONTRIB_NANOBIND_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/nanobind/include CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_NANOBIND_INCLUDE)