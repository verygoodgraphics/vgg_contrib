cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_minifb)

option(MINIFB_BUILD_EXAMPLES OFF)
add_subdirectory(upstream)

set(VGG_CONTRIB_MINIFB_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/include CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_MINIFB_INCLUDE)
