1����ϰ
-��T4�����edmx�ļ������Ӧ���������
-��log4net����־������
	�������裺������򼯣������ļ�����Global��ע�ᣬ����logִ��
	ע�⣺��1������log4net�����ռ�
	��2����xml��ʼ���Ĵ���ŵ�application_start��һ��
	��3������log����ʹ��web.config�е�����
-����¼����UI

2���ֲ�ʽ����memcached
-����������
	ע�⣺����·���в�Ҫ��������
	�Լ�ֵ�Եķ�ʽ�������ݴ洢
	��װ/ж�ط���memcached.exe -d install/uninstall
		ע�⣺Ҫ���Թ���Ա��ݽ��в���
	����/�رշ���memcached.exe -d start/stop
	Ĭ�϶˿ڣ�11211�����鲻Ҫ�ģ�����ͨ��ע�������޸�
	ʹ��telnet���ӣ���������μ���memcached - toxic - ����԰��
-�������ֲ�ʽ����ķ�������Ⱥ
	ͨ���Թ�ϣֵ����ķ�ʽ���л�ȡ������Ȼ��ͨ��socket����ͨ��
	ע�⣺��socketͨ������Ҫ������Ա����л�
-��һ���Թ�ϣ�㷨
-����.net��ʹ��mm���п������μ���Memcached ֮ .NET��C#��ʵ������ - ���׵��� - ����԰��
	��1���������
		��Commons.dll��ICSharpCode.SharpZipLib.dll��log4net.dll��Memcached.ClientLibrary.dll �ȷŵ�binĿ¼
		����Memcached.ClientLibrary.dll
	��2��д����
		��1�����÷�����IPstring[] servers = { "192.168.1.113:11211", "192.168.202.128:11211" };
		��2����ʼ�������
			SockIOPool pool = SockIOPool.GetInstance();
			pool.SetServers(servers);
			pool.Initialize();
		��3��ʵ����������в���
			MemcachedClient mc = new Memcached.ClientLibrary.MemcachedClient();
			mc.EnableCompression = false;
			��Ҫ�ķ�����Set��Add��Delete��Stats
-����ϵ���Ŀ�У�mm+cookie����session
	ΪʲôҪȥsession������������ܹ�����Ȼ�н�����session���������ܺܵ�
	��ͻ��˱���cookie��Response.Cookies.Add(HttpCookie�Ķ���);
	�������ύcookie��Request.Cookies[key];
	�������ԣ�Response.Cookies[key].Expired=...;
	С���⣺����Ҳ��Ҫ����log4net�������������򼯵İ汾�ǲ�һ�µģ�Ϊ���ܹ����棬���Ե�log4netԴ������������һ���������Ƶĳ��򼯣���log4net_log
	���裺��1����cookie�д洢guidֵ��ÿ�������ϴ����ֵ
		��2��ʹ�ÿͻ��˶��󣬸���guid��Ϊ�����в��Ҷ���

3��Ȩ��ģ�����
-�����ĵ�����
-����������
	�û�-����ɫ-��Ȩ�ޣ������ж��û��Ƿ���ĳ��Ȩ��
	���
	�϶������
		�û�A��1,2,3
		�����Aӵ��4Ȩ��
		A��Ȩ����ʲô��1��2��3��4
	�񶨷����
		�û�A��1��2��3
		�����A��ӵ��3Ȩ��
		A��Ȩ����ʲô��1��2
-�����ģ��
	����
	Ա��
	��ɫ
	Ȩ��
	���
-������ɾ����ʹ����ɾ��

���ű��
��������
�ϼ�����
�����ã������еı������ñ����е������У��������ϣ��������������������������ݵ�ֵ
1	����	0
2	֣��	1



�ϴ�ͼƬ���Ƿ���ͼƬ������Ҫ