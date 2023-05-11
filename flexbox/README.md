# README

## 使用流程

* 在`vgg_contrib`目录下，更新`yoga`

  ```shell
  $ git submodule update --init --recursive
  ```

* 编写`CMakeLists.txt`

  ```cmake
  #3.15 for CMP0091, for run flexbox_test
  cmake_minimum_required(VERSION 3.15.0)
  
  project(szn VERSION 0.1.0)
  
  add_subdirectory(vgg_contrib)
  add_executable(szn main.cpp)
  target_link_libraries(szn PRIVATE flexbox)
  target_include_directories(szn PRIVATE ${VGG_CONTRIB_FLEXBOX_INCLUDE})
  ```

* 运行测试用例（可选）：`flexbox_text`

* `main.cpp`

  ```c++
  #include <iostream>
  #include "flexbox_node.h"
  
  int main()
  {
      flexbox_node node;
      node.add_child();
      node.add_child();
  
      std::cout << node.child_count() << std::endl;
      // 2
  }
  ```



## todo

* `position_sticky`、`position_fixed`



## 测试

* 测试用例：运行`flexbox_test`
* 图形化展示：`flexbox/test/show_rect.py`