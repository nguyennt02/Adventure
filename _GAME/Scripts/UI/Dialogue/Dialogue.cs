using System.Collections.Generic;
public static class Dialogue
{
    public static List<BlogText> lstDialogue1 = new List<BlogText>()
    {
        new BlogText(Figure.FRIEND,$"Chào cậu! Cậu là ai và làm sao lại đến được đây?"),
        new BlogText(Figure.PLAYER,$"Ồ, xin lỗi, tôi cũng không biết nữa. Tôi vừa bị cuốn vào một vòng xoáy kỳ lạ và bỗng nhiên xuất hiện ở đây. Đây là đâu vậy?"),
        new BlogText(Figure.FRIEND,$"Cậu bị cuốn vào một vòng xoáy sao? Điều đó nghe kỳ lạ thật. Đây là thế giới {Figure.WORLD}. Tôi là {Figure.FRIEND}."),
        new BlogText(Figure.PLAYER,$"Thế giới {Figure.WORLD}? Vậy là tôi đã xuyên không ư? Tôi là {Figure.PLAYER}. Rất vui được gặp cậu, dù hoàn cảnh này có vẻ lạ lùng."),
        new BlogText(Figure.FRIEND,$"Rất vui được gặp cậu, {Figure.PLAYER}. Xem ra cậu đến từ một nơi rất xa. Cậu ổn chứ? Có bị thương gì không?"),
        new BlogText(Figure.PLAYER,$"Không, tôi không sao. Chỉ là vẫn chưa tin được những gì đang xảy ra thôi."),
        new BlogText(Figure.FRIEND,$"Tôi hiểu. Đến một nơi hoàn toàn mới có thể rất khó khăn. Nhưng đừng lo, tôi sẽ giúp cậu làm quen với nơi này. Trước hết, cậu có đói không? Chúng ta có thể đi kiếm gì đó ăn."),
        new BlogText(Figure.PLAYER,$"Ừ, cảm ơn cậu. Tôi đói lắm rồi."),
        new BlogText(Figure.FRIEND,$"Đi thôi. Chúng ta sẽ kiếm một chút hoa quả")
    };
    public static List<BlogText> lstDialogue2 = new List<BlogText>()
    {
        new BlogText(Figure.PLAYER,$"Ở đây trông thật khác lạ. Cây cối, không khí, mọi thứ đều mới mẻ."),
        new BlogText(Figure.FRIEND,$"Đúng vậy. {Figure.WORLD} có rất nhiều điều thú vị. Có thể cậu sẽ cần thời gian để làm quen, nhưng đừng lo, tôi sẽ dẫn cậu đi tham quan và giải thích mọi thứ."),
        new BlogText(Figure.PLAYER,$"Cảm ơn cậu. Cậu thật sự là một người bạn tốt. Tôi rất may mắn khi gặp được cậu."),
        new BlogText(Figure.FRIEND,$"Không có gì đâu. Bạn bè mà. Chúng ta sẽ cùng nhau vượt qua mọi khó khăn."),
        new BlogText(Figure.FRIEND,$"Được rồi, chắc chúng ta nên về làng thôi. Cậu sẽ cần một chỗ để nghỉ ngơi và làm quen với mọi người."),
    };
    public static List<BlogText> lstDialogue3 = new List<BlogText>()
    {
        new BlogText(Figure.FRIEND,$"Chuyện gì đang xảy ra vậy?"),
        new BlogText(Figure.FRIEND,$"Đó là làng của tôi! Có chuyện gì đó không ổn. Nhanh lên, chúng ta phải đến đó ngay!"),
    };
    public static List<BlogText> lstDialogue4 = new List<BlogText>()
    {
        new BlogText(Figure.VILLAGE_CHIEF,$"{Figure.FRIEND}! Cậu về rồi à? Chúng tôi cần sự giúp đỡ của cậu!"),
        new BlogText(Figure.FRIEND,$"Đừng lo, tôi ở đây rồi. {Figure.VILLAGE_CHIEF}, đây là {Figure.PLAYER}, một người bạn mới. Cậu ấy có thể giúp chúng ta."),
        new BlogText(Figure.VILLAGE_CHIEF,$"{Figure.PLAYER}, nếu cậu có thể giúp, xin hãy làm ơn. Chúng tôi đang gặp nguy hiểm."),
        new BlogText(Figure.PLAYER,$"Tôi sẽ làm hết sức mình. Chúng ta phải làm gì?"),
        new BlogText(Figure.FRIEND,$"Chúng ta cần tập trung vào con quái vật lớn nhất. Nếu đánh bại được nó, những con khác có thể sẽ rút lui. Hãy chia nhau ra. Tôi sẽ dẫn một nhóm, còn cậu đi cùng trưởng làng."),
        new BlogText(Figure.PLAYER,$"Được, chúng ta làm thôi!"),
    };
    public static List<BlogText> lstDialogue5 = new List<BlogText>()
    {
        new BlogText(Figure.FRIEND,$"Chúng ta làm được rồi! Bọn quái vật đang rút lui!"),
        new BlogText(Figure.VILLAGE_CHIEF,$"Tốt lắm, mọi người. Chúng ta đã đánh bại được chúng. Cảm ơn cậu, {Figure.PLAYER}. Cậu đã cứu ngôi làng của chúng tôi."),
        new BlogText(Figure.PLAYER,$"Tôi chỉ làm những gì cần làm thôi. Cảm ơn mọi người đã chiến đấu dũng cảm."),
        new BlogText(Figure.FRIEND,$"Giờ thì chúng ta có thể an tâm trở về và nghỉ ngơi. Cậu đúng là một người bạn tốt, {Figure.PLAYER}."),
        new BlogText(Figure.VILLAGE_CHIEF,$"Chúng tôi rất biết ơn cậu. Hãy coi nơi này như nhà của mình. Chúng ta sẽ tổ chức một bữa tiệc lớn để cảm ơn cậu."),
        new BlogText(Figure.PLAYER,$"Cảm ơn ông. Tôi rất vui vì đã có thể giúp đỡ."),
    };
    public static List<BlogText> lstDialogue6 = new List<BlogText>()
    {
        new BlogText(Figure.FRIEND,$"Em gái tôi đâu rồi? Tôi không thấy em ấy đâu cả!"),
        new BlogText(Figure.PLAYER,$"Có chuyện gì sao?"),
        new BlogText(Figure.FRIEND,$"Em gái tôi, {Figure.SISTER}, không thấy đâu. Chắc chắn em ấy đã bị quái vật bắt đi!"),
        new BlogText(Figure.VILLAGE_CHIEF,$"Điều này không ổn rồi. Nếu bọn quái vật bắt em gái cậu, chúng có thể đã đưa em ấy về sào huyệt của chúng."),
        new BlogText(Figure.PLAYER,$"Chúng ta không thể để chuyện này xảy ra. {Figure.FRIEND}, tôi sẽ giúp cậu. Chúng ta sẽ giải cứu em gái cậu."),
        new BlogText(Figure.FRIEND,$"Cảm ơn cậu, {Figure.PLAYER}. Tôi không thể làm điều này một mình. Chúng ta cần phải hành động ngay lập tức."),
        new BlogText(Figure.VILLAGE_CHIEF,$"Tôi sẽ chuẩn bị một số vật dụng và vũ khí cho các cậu. Các cậu cần đi ngay bây giờ, trước khi quá muộn."),
        new BlogText(Figure.PLAYER,$"Được, chúng ta đi thôi."),
    };
    public static List<BlogText> lstDialogue7 = new List<BlogText>()
    {
        new BlogText(Figure.FRIEND,$"Chúng ta đã đến nơi. Chúng ta cần phải lén vào và tìm em gái tôi trước khi bị phát hiện."),
        new BlogText(Figure.PLAYER,$" Được, hãy cẩn thận và giữ im lặng."),
    };
    public static List<BlogText> lstDialogue8 = new List<BlogText>()
    {
        new BlogText(Figure.PLAYER,$"Ôi không! Chúng ta đã bị phát hiện."),
        new BlogText(Figure.PLAYER,$"Chuẩn bị sãn sàng. Chúng ta phải đánh bại thủ lĩnh của chúng."),
    };
    public static List<BlogText> lstDialogue9 = new List<BlogText>()
    {
        new BlogText(Figure.SISTER,$"Anh! Em sợ lắm. Cảm ơn vì đã đến cứu em."),
        new BlogText(Figure.PLAYER,$"Đừng lo! Thủ lĩnh của bọn chúng đã bị bọn anh đánh bại. Chúng ta đã an toàn"),
    };
}
