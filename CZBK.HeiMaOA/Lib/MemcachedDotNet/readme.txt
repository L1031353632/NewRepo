1、复习
-》T4：结合edmx文件完成相应代码的生成
-》log4net：日志处理框架
	基本步骤：引入程序集，配置文件，在Global中注册，调用log执行
	注意：（1）引用log4net命名空间
	（2）将xml初始化的代码放到application_start第一句
	（3）构造log对象，使用web.config中的名称
-》登录，主UI

2、分布式缓存memcached
-》基本操作
	注意：操作路径中不要出现中文
	以键值对的方式进行数据存储
	安装/卸载服务：memcached.exe -d install/uninstall
		注意：要求以管理员身份进行操作
	启动/关闭服务：memcached.exe -d start/stop
	默认端口：11211；建议不要改，可以通过注册表进行修改
	使用telnet连接，基本命令：参见“memcached - toxic - 博客园”
-》建立分布式缓存的服务器集群
	通过对哈希值求余的方式进行获取主机，然后通过socket进行通信
	注意：在socket通信中需要对象可以被序列化
-》一致性哈希算法
-》在.net中使用mm进行开发，参见“Memcached 之 .NET（C#）实例分析 - 海底的鱼 - 博客园”
	（1）引入程序集
		将Commons.dll，ICSharpCode.SharpZipLib.dll，log4net.dll，Memcached.ClientLibrary.dll 等放到bin目录
		引用Memcached.ClientLibrary.dll
	（2）写代码
		《1》配置服务器IPstring[] servers = { "192.168.1.113:11211", "192.168.202.128:11211" };
		《2》初始化缓存池
			SockIOPool pool = SockIOPool.GetInstance();
			pool.SetServers(servers);
			pool.Initialize();
		《3》实例化对象进行操作
			MemcachedClient mc = new Memcached.ClientLibrary.MemcachedClient();
			mc.EnableCompression = false;
			主要的方法：Set，Add，Delete，Stats
-》结合到项目中：mm+cookie代替session
	为什么要去session：多服务器不能共享，虽然有进程外session，但是性能很低
	向客户端保存cookie：Response.Cookies.Add(HttpCookie的对象);
	向服务端提交cookie：Request.Cookies[key];
	设置属性：Response.Cookies[key].Expired=...;
	小问题：这里也需要引入log4net，但是两个程序集的版本是不一致的，为了能够并存，可以到log4net源码中重新生成一个其它名称的程序集，如log4net_log
	步骤：（1）在cookie中存储guid值，每次请求上传这个值
		（2）使用客户端对象，根据guid作为键进行查找对象

3、权限模块设计
-》看文档讨论
-》分析讲解
	用户-》角色-》权限：最终判断用户是否有某个权限
	否决
	肯定否决：
		用户A：1,2,3
		否决：A拥有4权限
		A的权限是什么：1，2，3，4
	否定否决：
		用户A：1，2，3
		否决：A不拥有3权限
		A的权限是什么：1，2
-》设计模型
	部门
	员工
	角色
	权限
	否决
-》关于删除：使用软删除

部门编号
部门名称
上级部门
自引用：本表中的表在引用本表中的主键列，而数据上，是这行数据在引用其它行数据的值
1	河南	0
2	郑州	1



上传图片，是否有图片并不重要