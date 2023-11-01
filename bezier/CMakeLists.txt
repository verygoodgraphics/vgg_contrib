cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_bezier)

set(VGG_CONTRIB_BEZIER_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_BEZIER_INCLUDE)