from flask import Flask
from bs4 import BeautifulSoup
import requests,time

app = Flask(__name__)
@app.route('/')
def one():
    res = requests.get("http://fancyworld.janfusun.com.tw/news.aspx")
    bs = BeautifulSoup(res.text, "html.parser")
    for i in bs.select(".news_list>a")[0]:
        try:
            picture = "http://fancyworld.janfusun.com.tw/" + i["src"]
            title= i["alt"]
            href = []
            for x in bs.select("div.news_list>a"):
                href.append(x["href"])
            link = "http://fancyworld.janfusun.com.tw/" + href[0]
            re2 = requests.get("http://fancyworld.janfusun.com.tw/" + href[0])
            bs2 = BeautifulSoup(re2.text, "html.parser")
            for ii in bs2.select("td"):
                texts = ii.text
        except AttributeError:
            pass
    return '<img src ={} width="600" height="700"></br><h2>{}<h2></br><p><a target="_blank" href={}>頁面連結</a></p><p style="font-size:13px;">{}</p>'.format(picture,title,link,texts)

@app.route('/two')
def two():
    time.sleep(1)
    res = requests.get("http://fancyworld.janfusun.com.tw/news.aspx")
    bs = BeautifulSoup(res.text, "html.parser")
    for i in bs.select(".news_list>a")[1]:
        try:
            picture = "http://fancyworld.janfusun.com.tw/" + i["src"]
            title= i["alt"]
            href = []
            for x in bs.select("div.news_list>a"):
                href.append(x["href"])
            link = "http://fancyworld.janfusun.com.tw/" + href[1]
            re2 = requests.get("http://fancyworld.janfusun.com.tw/" + href[1])
            bs2 = BeautifulSoup(re2.text, "html.parser")
            for ii in bs2.select("td"):
                texts = ii.text
        except AttributeError:
            pass

    return '<img src ={} width="600" height="700"></br><h2>{}<h2></br><p><a target="_blank" href={}>頁面連結</a></p><p style="font-size:13px;">{}</p>'.format(picture,title,link,texts)
@app.route('/car')
def car():
    res = requests.get("https://www.ponyrent.com.tw/")
    bs = BeautifulSoup(res.text, "html.parser")
    for i in bs.select("ul.news-list>.item")[0]:
        try:
            title = i.text
            titles = title.replace(" ", "")
            titles = titles.replace("\n", "")
        except AttributeError:
            pass
    link_list = []
    for i in bs.select("ul.news-list>.item>a"):
        link_list.append(i["href"])
    link = "https://www.ponyrent.com.tw/" + link_list[0]
    res1 = requests.get("https://www.ponyrent.com.tw/" + link_list[0])
    bs1 = BeautifulSoup(res1.text, "html.parser")
    pic = bs1.select_one(".editor.news-page>div>img")
    picture= pic["src"]
    return '<img src ={} width="600" height="700"></br><h3>{}<h3></br><p><a target="_blank" href={}>頁面連結</a>'.format(picture,titles,link)
@app.route('/car2')
def car2():
    res = requests.get("https://www.ponyrent.com.tw/")
    bs = BeautifulSoup(res.text, "html.parser")
    for i in bs.select("ul.news-list>.item")[1]:
        try:
            title = i.text
            titles = title.replace(" ", "")
            titles = titles.replace("\n", "")
        except AttributeError:
            pass
    link_list = []
    for i in bs.select("ul.news-list>.item>a"):
        link_list.append(i["href"])
    link = "https://www.ponyrent.com.tw/" + link_list[1]
    res1 = requests.get("https://www.ponyrent.com.tw/" + link_list[1])
    bs1 = BeautifulSoup(res1.text, "html.parser")
    pic = bs1.select_one(".editor.news-page>div>img")
    picture= pic["src"]
    return '<img src ={} width="600" height="700"></br><h3>{}<h3></br><p><a target="_blank" href={}>頁面連結</a>'.format(picture,titles,link)
@app.route('/ETtoday')
def ETtoday():
    textlist = []
    res = requests.get(
        "https://www.google.com/search?q=%E9%96%8B%E8%8A%B1%E6%96%B0%E8%81%9E+site:https://travel.ettoday.net/&lr=&as_rights=%E4%B8%8D%E9%99%90%E4%BD%BF%E7%94%A8%E6%AC%8A&sxsrf=ALeKk01MONVEX9Uw-D5RZ7A7n98umnfh4A:1592234206392&source=lnt&tbs=qdr:m&sa=X&ved=0ahUKEwj6lpPSjoTqAhX-yosBHUr0AAAQpwUIEw")
    bs = BeautifulSoup(res.text, "html.parser")
    for i in bs.select(".BNeawe.vvjwJb.AP7Wnd"):
        if "第1頁" in i.text or "行動版" in i.text:
            pass
        else:
            texts =  i.text
            textlist.append(texts[:-4])
    linklist = []
    lens1 = len( "https://travel.ettoday.net/article/1727870.htm&sa=U&ved=2ahUKEwj-kOSEp4XqAhUDeysKHWMTCRYQFjAJegQIABAB&usg=AOvVaw1A5ddxy9QkdTy6Moo_vYzx")
    lens = len("https://travel.ettoday.net/category/%25E5%258F%25B0%25E5%258C%2597/&sa=U&ved=2ahUKEwjYzcjImITqAhUrGKYKHQTWA0gQFjAEegQIBxAB&usg=AOvVaw1GgN_KPz5_FOguqOsfqOkY")
    for i in bs.select(".kCrYT>a"):
        text = i["href"]
        if len(text) >= lens or len(text) < lens1:
            pass
        else:
            linklist.append(text[7:])
    # conn = pyodbc.connect('Driver={SQL Server};'
    #                       'Server=DESKTOP-GEQ26LU\SQLEXPRESS;'
    #                       'Database=Reservation;')
    #
    # cursor = conn.cursor()
    # for r in range(len(textlist)):
    #     cursor.execute(f"insert into Reservation.dbo.ettoday (title,link) values  ('{textlist[0+r]}','{linklist[0+r]}')")
    #     conn.commit()

    return f'<h3><a target="_blank" href={linklist[0]}>{textlist[0]}</a><h3></br>' \
           f'<h3><a target="_blank" href={linklist[1]}>{textlist[1]}</a><h3></br>' \
           f'<h3><a target="_blank" href={linklist[2]}>{textlist[2]}</a><h3></br>' \
           f'<h3><a target="_blank" href={linklist[3]}>{textlist[3]}</a><h3></br>' \
           f'<h3><a target="_blank" href={linklist[4]}>{textlist[4]}</a><h3></br>' \
           f'<h3><a target="_blank" href={linklist[5]}>{textlist[5]}</a><h3></br>'
if __name__ == '__main__':
    app.run()