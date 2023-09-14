cmake_minimum_required(VERSION 3.13)

project(vgg_contrib_libpng)

option(PNG_EXECUTABLES OFF)
option(PNG_TESTS OFF)
set(PNG_BUILD_ZLIB ON CACHE BOOL "" FORCE)
if (NOT VGG_CONTRIB_ZLIB_INCLUDE)
  message(FATAL_ERROR "Please add zlib first for libpng")
endif()
set(ZLIB_INCLUDE_DIR ${VGG_CONTRIB_ZLIB_INCLUDE} ${VGG_CONTRIB_ZLIB_CONF_INCLUDE}) # for upstream/scripts/genout.cmake.in
set(ZLIB_INCLUDE_DIRS ${VGG_CONTRIB_ZLIB_INCLUDE} ${VGG_CONTRIB_ZLIB_CONF_INCLUDE})

option(LIBPNG_USE_STATIC_ZLIB "libpng use static zlib" OFF)
if(LIBPNG_USE_STATIC_ZLIB)
  set(ZLIB_LIBRARIES $<BUILD_INTERFACE:zlibstatic>)  
else()
  set(ZLIB_LIBRARIES $<BUILD_INTERFACE:zlib>)  
endif()

add_subdirectory(upstream)

set(VGG_CONTRIB_LIBPNG_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/ CACHE PATH "" FORCE)
set(VGG_CONTRIB_LIBPNG_CONF_INCLUDE ${CMAKE_CURRENT_BINARY_DIR}/upstream/ CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_LIBPNG_INCLUDE)
mark_as_advanced(VGG_CONTRIB_LIBPNG_CONF_INCLUDE)
