# Prototype Design Pattern - LinkedIn Post

## Post Links

- **LinkedIn Post**: [View Post](https://www.linkedin.com/feed/update/urn:li:activity:7513968549996974081/)
- **LinkedIn Profile**: [Omar Salem Profile](https://www.linkedin.com/in/omarsalem33)

---

## Post Content

ازاي بيحل مشكلة معقدة في استهلاك الموارد أثناء إنشاء Prototype Design Pattern
المشكلة لما نحتاج ننشئ عدد كبير من الأعداء زي ال new في اللعبة وكل مرة نعمل Orc
الأبليكشن يرجع يحمل البيانات وال Model من جديد وده يسبب بطء شديد غير إن الطرق 3D
العادية للنسخ كانت تعمل Shallow Copy وكمان تفشل objs وتشارك الأسلحة والقدرات بين
في نسخ البيانات الخاصة مثل \_modelData

هو إننا ننشئ Prototype Pattern واحد كنسخة أصلية ثم نستخدم دالة Clone لنسخ obj
في الميموري مباشرة بدون إعادة تحميل البيانات مع تنفيذ Deep Copy لضمان إن التعديل
على سلاح أو قدرات النسخة الجديدة مش هيأثر على obj الأصلي وبدون ما نحتاج تعرف نوع
العدو سواء كان Orc أو Elf في الكود الرئيسي

نستخدم النمط ده لما يكون إنشاء obj مع زمان مكلف في الوقت أو الموارد أو لما نحتاج ننسخ
اللي لازم ناخد بالنا منه هو الفرق بين Shallow Copy وال الحفاظ على حالته الداخلية والشيء
Deep Copy

#DesignPatterns #CSharp #DotNet #SoftwareDesign #CleanCode #OOP #Programming
#csharp #dotnet #softwareengineering #cleanarchitecture #designpatterns #objectorientedprogramming #codingtips #linkedinlearning #SimulationAcademy
