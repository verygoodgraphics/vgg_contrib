cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_libjpg)

option(WITH_TURBOJPEG OFF)
add_subdirectory(upstream)

set(VGG_CONTRIB_LIBJPG_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/ CACHE PATH "" FORCE)
set(VGG_CONTRIB_LIBJPG_CONF_INCLUDE ${CMAKE_CURRENT_BINARY_DIR}/upstream/ CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_LIBJPG_INCLUDE)
mark_as_advanced(VGG_CONTRIB_LIBJPG_CONF_INCLUDE)
