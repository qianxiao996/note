import requests,itchat,re,time
import json
def getNews():
    try:
       cve_all = []
       cve_single=[]
       headers = {"User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36"}
       api = "https://api.github.com/search/repositories?q=CVE-2020&sort=updated"
       req = requests.get(api,headers = headers).text
       json2 = json.loads(req)
       cve_total_count=json2['total_count']
       cve_url=json2['items'][0]['html_url']
       for i in json2['items']:
          cve_single.append(i['id'])
          cve_single.append(i['name'])
          cve_single.append(i['html_url'])
          cve_all.append(cve_single)
       return cve_total_count,cve_all
    except Exception as e:
       return None,None
      #  print (e,"github链接不通")

def sendNews():
   try:
      headers = {"User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36"}
      api = "https://sc.ftqq.com/SCU95037T32c8eca0de7bccccc96a9b3e0c62faec5e9fed613ab7c.send"
      while True:
         total =  getNews()
         total_count = total[0]
         print(total_count)
         total_all= total[1]
         # print(total_all)
         if total_count!=None:
            time.sleep(60)
            data = getNews()
            print(data[0])
            if  data[0]!=None and total_count!=data[0]:
               cve_all = data[1]
               # print(cve_all)
               title='有新的CVE-EXP了！'
               all_cve_url=[]
               for i in cve_all:
                  if i not in total_all:
                     cve_description = i[1]
                     cve_url= i[2]
                     single_vul = cve_description+'  '+cve_url+'\n'
                     if single_vul not in all_cve_url:
                        all_cve_url.append(cve_description+'  '+cve_url+'\n')
               data = {
                  "text":title,
                  "desp":all_cve_url
               }
               req2 = requests.post(api,data = data,headers = headers)
            else:
               pass
            time.sleep(2)
         else:
            time.sleep(5)
   except Exception as e:
      pass
if __name__ == '__main__':
    sendNews()