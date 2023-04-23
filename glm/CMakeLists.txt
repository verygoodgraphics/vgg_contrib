# 3.24 for find_package GLOBAL keyword
cmake_minimum_required(VERSION 3.24)

project(vgg_contrib_glm)

add_subdirectory(upstream)

set(VGG_CONTRIB_GLM_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_GLM_INCLUDE)
