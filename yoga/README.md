# README

## 使用说明

* 链接库：`yogacore`
* 头文件：`yoga/Yoga.h`



## 示例

* `CMakeLists.txt`示例

  ```cmake
  cmake_minimum_required(VERSION 3.0.0)
  project(szn_test VERSION 0.1.0)
  
  add_subdirectory(vgg_contrib)
  add_executable(szn_test main.cpp)
  target_link_libraries(szn_test PRIVATE yogacore)
  ```

* `main.cpp`示例

  ```c++
  #include <fstream>
  #include <iostream>
  #include "yoga/Yoga.h"
  
  int main()
  {
  	const YGConfigRef config = YGConfigNew();
  	const YGNodeRef root = YGNodeNewWithConfig(config);
  
  	YGNodeStyleSetWidth(root, 500);
  	YGNodeStyleSetHeight(root, 500);
  
  	const YGNodeRef root_child0 = YGNodeNewWithConfig(config);
  	YGNodeStyleSetPositionType(root_child0, YGPositionTypeRelative);
  	YGNodeStyleSetWidth(root_child0, 100);
  	YGNodeStyleSetHeight(root_child0, 100);
  	YGNodeInsertChild(root, root_child0, 0);
  
  	const YGNodeRef root_child1 = YGNodeNewWithConfig(config);
  	YGNodeStyleSetPositionType(root_child1, YGPositionTypeRelative);
  	YGNodeStyleSetWidth(root_child1, 200);
  	YGNodeStyleSetHeight(root_child1, 200);
  	YGNodeInsertChild(root, root_child1, 1);
  
  	YGNodeCalculateLayout(root, YGUndefined, YGUndefined, YGDirectionRTL);
  
  	YGNodeFreeRecursive(root);
  	YGConfigFree(config);
  
  	std::cout << "finish" << std::endl;
  }
  ```