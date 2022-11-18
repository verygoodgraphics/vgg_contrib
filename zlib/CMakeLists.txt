cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_zlib)

if (APPLE)
  set(CMAKE_MACOSX_RPATH ON)
endif()
add_subdirectory(upstream)

set(VGG_CONTRIB_ZLIB_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream CACHE PATH "" FORCE)
set(VGG_CONTRIB_ZCONF_INCLUDE ${CMAKE_CURRENT_BINARY_DIR}/upstream CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_ZLIB_INCLUDE)
mark_as_advanced(VGG_CONTRIB_ZCONF_INCLUDE)
