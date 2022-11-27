# Boost for VGG Contrib

The `upstream` keeps a minified boost distribution with

- Complete boost headers
- Selected boost libs that VGG projects use, for space-saving purpose

The current boost sub-libs we are building

| Link Target: Static Lib |
| ----------------------- |
| `boost_thread`          |
| `boost_atomic`          |
| `boost_chrono`          |
| `boost_container`       |
| `boost_date_time`       |
| `boost_exception`       |
| `boost_locale`          |
| `boost_context`         |
| `boost_coroutine`       |

If you want to add more libs, please copy files into `libs` directory from full boost distribution.
