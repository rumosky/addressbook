## 通讯录

Windows 窗体程序，VS2019 版，NET Framework 4.7.2，MySQL 5.7.24

国内 Gitee 地址：https://gitee.com/rumosky_admin/addressbook

Github 地址：https://github.com/rumosky/addressbook

### 安装使用

前往 Release 下载`Setup.exe`，安装后即可预览
（由于 Mysql 在服务器上，已经关闭，请自行配置数据库后打包使用）

### 自行编译

数据库信息：
表名：addressbook
字段：uid（自增主键，不为空）name，sex，phone，email

修改 ManageDatabase.cs 文件中下面内容为自己的数据库地址：

```cs
String url = "server=127.0.0.1;port=3306;user=root;password=test@1234; database=classofc;Charset=utf8;";
```

### 其他

帮助文档使用`easyCHM`生成，可执行文件使用`innosetup`打包
