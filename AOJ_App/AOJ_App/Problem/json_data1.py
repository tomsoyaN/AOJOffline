import json
import os
import csv

ABC = ["A","B","C","D"]

with open('ITP1.csv', 'w',encoding="utf_8_sig") as f:
    for i in range(11):
        for j in range(4):
            path = "ITP1_" + str(i+1) + "_" + str(ABC[j])
            print(path)
            json_file = open(path +'.json', 'r',encoding="utf_8_sig")
            json_object = json.load(json_file)
            #print("problem_id:",json_object["problem_id"])
            writer = csv.writer(f)
            writer.writerow(["ITLP1",i+1,ABC[j],json_object["problem_id"],json_object["html"]])
            print("problem_id:",json_object["problem_id"])
            #print(json_object["html"])

"""
json_file = open('ITP1_1_A.json', 'r',encoding="utf_8_sig")
json_object = json.load(json_file)

print("problem_id:",json_object["problem_id"])
print(json_object["html"])

"""