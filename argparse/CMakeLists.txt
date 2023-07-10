cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_argparse)

set(VGG_CONTRIB_ARGPARSE_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/include CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_ARGPARSE_INCLUDE)
