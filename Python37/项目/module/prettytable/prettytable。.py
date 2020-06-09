from prettytable import PrettyTable
x = PrettyTable(["名称", "年龄"])
x.align = "l"  # 左对齐
x.padding_width = 1  # 列数据左右的空格数量

x.add_row(["王大壮", 20])
x.add_row(["老牛", 10])
x.add_row(["老王 ", 56])
x.add_row(["王二狗", 22])
x.add_row(["小黑", 55])
x.add_row(["爸比", 14])

print(x)