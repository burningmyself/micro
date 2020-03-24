我们非常欢迎社区的开发者向 abp vnext miro 做出贡献。在提交贡献之前，请花一些时间阅读以下内容，保证贡献是符合规范并且能帮助到社区。

## miro 组成

| application                                                                                                      | 应用服务                        |
| ----------------------------------------------------------------------------------------| :-------------------------------|
| [Base.HttpApi.Host](https://github.com/burningmyself/micro/tree/master/modules/base/host/Base.HttpApi.Host)      | 基础服务api                     |
| [Base.IdentityServer](https://github.com/burningmyself/micro/tree/master/modules/base/host/Base.IdentityServer)  | 身份认证服务api                 |
| gateways                                                                                                         | 网关服务                        |
| ----------------------------------------------------------------------------------------| :-------------------------------|
| [AdminApiGateway.Host](https://github.com/burningmyself/micro/tree/master/gateways/AdminApiGateway.Host)         | 网关服务                        |
| modules                                                                                                          | 模块                            |
| -base                                                                                                            | 基础模块                        |
| -public                                                                                                          | 微服务公用类库                  |


## Issue 报告指南

如果提交的是 Bug 报告，请务必遵守 [`Bug report`](https://github.com/buringmyself/micro/.github/ISSUE_TEMPLATE/bug_report.md) 模板。

如果提交的是功能需求，请在 issue 的标题的起始处增加 `[Feature request]` 字符。

## 提交 commit

整个 micro 仓库遵从 [Angular Style Commit Message Conventions](https://gist.github.com/stephenparish/9941e89d80e2bc58a153)，在输入 commit message 的时候请务必遵从此规范。


## Pull Request 指南
[Pull Request 指南](https://github.com/buringmyself/micro/.github/PULL_REQUEST_TEMPLATE.md)
1. 务必保证 `dotnet run build` 能够编译成功；
2. 务必保证提交到代码遵循相关包中所规定的规范；
3. 当相关包的含有test时，必须保证所有测试用例都需要通过；
4. 当相关包有测试用例时，请给你提交的代码也添加相应的测试用例；
5. 提交代码 commit 时，commit 信息需要遵循 [Angular Style Commit Message Conventions](https://gist.github.com/stephenparish/9941e89d80e2bc58a153)。
6. 如果提交到代码非常多或功能复杂，可以把 PR 分成几个 commit 一起提交。我们在合并时会会根据情况 squash。

