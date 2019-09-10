
# 构建符合 Restful 风格的接口
HTTP状态码	涵义	解释说明
200	OK	用于一般性的成功返回，不可用于请求错误返回
201	Created	资源被创建
202	Accepted	用于资源异步处理的返回，仅表示请求已经收到。对于耗时比较久的处理，一般用异步处理来完成
204	No Content	此状态可能会出现在 PUT、POST、DELETE 的请求中，一般表示资源存在，但消息体中不会返回任何资源相关的状态或信息
400	Bad Request	用于客户端一般性错误信息返回, 在其它 4xx 错误以外的错误，也可以使用，错误信息一般置于 body 中
401	Unauthorized	接口需要授权访问，为通过授权验证
403	Forbidden	当前的资源被禁止访问
404	Not Found	找不到对应的信息
500	Internal Server Error	服务器内部错误


HTTP谓词方法	解释说明
GET	获取资源信息
POST	提交新的资源信息
PUT	更新已有的资源信息
DELETE	删除资源

HTTP状态码	方法名称
200	OK()
201	Created()
202	Accepted()
204	NoContent()
400	BadRequest()
401	Unauthorized()
403	Forbid()
404	NotFound()