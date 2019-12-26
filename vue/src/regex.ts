export class regex {
    /**
     * 至少8-16个字符，至少1个大写字母，1个小写字母和1个数字，其他可以是任意字符：
     */
    static loginPass: any = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[^]{6,16}$/
}
