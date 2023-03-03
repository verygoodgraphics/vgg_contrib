cmake_minimum_required(VERSION 3.0.0)

project(vgg_contrib_zip)

add_subdirectory(upstream)

set(VGG_CONTRIB_ZIP_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/src CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_ZIP_INCLUDE)
