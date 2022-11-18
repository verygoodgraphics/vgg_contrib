cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_zstd)

option(ZSTD_BUILD_PROGRAMS OFF)
add_subdirectory(upstream/build/cmake)

set(VGG_CONTRIB_ZSTD_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/lib CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_ZSTD_INCLUDE)
