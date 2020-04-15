import json
import os
import csv

ABC = ["A","B","C","D"]

with open('ITP1_testdata.csv', 'w',encoding="utf_16") as f:
    for i in range(11):
        for j in range(4):
            path1 = "ITP1_" + str(i+1) + "_" + str(ABC[j])
            for k in range(20):
                path = "ITP1_" + str(i+1) + "_" + str(ABC[j]) + "_" + str(k+1)
                #print(path)
                json_file = open(path +'.json', 'r',encoding="utf_16")
                
                json_object = json.load(json_file)
                msg = str(json_object)
                #print("msg",msg)
                aa = "[{'id': 2004, 'code': 'RESOURCE_NOT_EXIST_ERROR', 'message': 'Test case #"+str(k+1)+" for problem "+ path1+" is not available.\"}]"
                #print("msg",aa)
                if msg[0] == "[":
                    print("path1")
                else: 
                    writer = csv.writer(f)
                    a = json_object["problemId"]
                    b = str(json_object["serial"])
                    c = str(json_object["in"])
                    d = str(json_object["out"])
                    a = a.translate(str.maketrans({'\n' : '\\n',}))
                    b = b.translate(str.maketrans({'\n' : '\\n',}))
                    c = c.translate(str.maketrans({'\n' : '\\n',}))
                    d = d.translate(str.maketrans({'\n' : '\\n',}))

                    
                    
                    writer.writerow((str(a) , str(b) , str(c) , str(d)))

                    #writer.writerow([str(json_object["problemId"]),str(json_object["serial"]),str(json_object["in"]),str(json_object["out"])])
                    print("problem_id:",json_object["problemId"])
                    #print(json_object["html"])
                

"""

json_file = open('ITP1_1_A_1.json', 'r',encoding="utf_16")
json_object = json.load(json_file)
#print("a",json_object[0])
msg = str(json_object)
#print(msg[0])
aa = "{'id': 2004, 'code': 'RESOURCE_NOT_EXIST_ERROR', 'message': 'Test case #"+str(2)+" for problem "+"ITP1_1_A" +" is not available.\"}"
#print(aa)
#print(msg)
if msg[0] == "[":
    print("path1")
else:
    #print("A")
    aa = [str(json_object["problemId"]),str(json_object["serial"]),str(json_object["in"]),str(json_object["out"])]
    #print([str(json_object["problemId"]),str(json_object["serial"]),str(json_object["in"]),str(json_object["out"])])
    a = json_object["problemId"]
    b = str(json_object["serial"])
    c = str(json_object["in"])
    d = str(json_object["out"])
    #print(a,str(b),(c),d)
    #print(str(aa[2]))
    a = a.translate(str.maketrans({'\n' : '\\n',}))
    b = b.translate(str.maketrans({'\n' : '\\n',}))
    c = c.translate(str.maketrans({'\n' : '\\n',}))
    d = d.translate(str.maketrans({'\n' : '\\n',}))

    a = a.split(",")
    print(a)
print(a,b,c,d)
print(c)
"""