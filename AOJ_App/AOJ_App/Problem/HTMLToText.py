#python_text.py
import csv
import pprint
import string
# ファイル入力(csv)
data = []
with open('ITP1.csv') as f:
    reader = csv.reader(f)
    l = [row for row in reader]
"""
<H1>Hello World</H1><br>

<p>
オンラインジャッジへようこそ。
</p>
"""
# HTML to Text
num = len(l)
for i in range(44):
    filename = "output/"+l[i][3] + ".txt"
    with open(filename,'w') as f:
        flag = 0
        for j in range(len(l[i][4])):
            if "<" == l[i][4][j]:
                flag = 1
            if flag == 0:
                text = l[i][4][j]
                #print(text)
                f.write(text)
            if ">" == l[i][4][j]:
                flag = 0

flag =0
# Get Problem info
with open("ITP1_info.txt","w") as f:
    for i in range(44):
        f.write(l[i][3] + ":")
        for j in range(30):#len(l[i][4])):
            print(l[i][4][j:j+4],flag)
            if "<H1>" == l[i][4][j:j+4]:
                flag =1
            if "</H1>"  == l[i][4][j:j+5]:
                flag = 0
            if flag == 1:
                text = l[i][4][j+4]
                if "<" == text:
                    flag == 0
                    break
                elif ">" == text:
                    print(text)
                else:
                    #print(text)
                    f.write(text)
        f.write("\n")

