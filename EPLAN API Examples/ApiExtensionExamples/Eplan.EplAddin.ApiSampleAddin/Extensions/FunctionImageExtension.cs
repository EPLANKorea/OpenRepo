using Eplan.EplAddin.ApiSampleAddin.Helpers;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.Graphics;
using System;
using System.Linq;

namespace Eplan.EplAddin.ApiSampleAddin.Extensions
{
    /// <summary>
    /// 장치(Device)의 Image를 자동으로 표시하는 Extension
    /// - Function에 대해서만 작동
    /// </summary>
    public static class FunctionImageExtension
    {
        private static ISOCode _eplanGUILanguage = ApiExtHelpers.GetEplanGUILanguage();

        /// <summary>
        /// 지정된 Functiuon에 대하여, 이미지를 생성
        /// - 이미 생성된 이미지가 있는 경우, 기존 이미지를 삭제하고 신규로 생성하는 방식 사용
        /// - 이미지 너비(Width)만 지정하고, 높이(Height)는 이미지 비율에 따라 자동으로 지정됨
        /// </summary>
        /// <param name="function">대상 Function</param>
        /// <param name="imageWidth">이미지 너비</param>
        /// <param name="gapFromSymbol">심볼에서 이미지 배치 상대 위치, (-): 왼쪽 배치, (+): 오른쪽 배치</param>
        public static void DoImage(this Function function, double imageWidth = 30.0, double gapFromSymbol = -10)
        {
            if (function == null)
                throw new ArgumentNullException("function");

            Image functionImage = null;

            try
            {
                using (SafetyPoint safetyPoint = SafetyPoint.Create())
                {
                    functionImage = FindFunctionImage(function);
                    Article part = function.Articles.FirstOrDefault();

                    if (functionImage != null)
                    {
                        functionImage.Remove();
                        functionImage = null;
                    }

                    if (part != null)
                        CreateNewImage(function, part, imageWidth, gapFromSymbol);

                    safetyPoint.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("이미지 박스 추가 실패{1}ex.Message=[{0}]", ex.Message, Environment.NewLine), "DoImage", EnumDecisionIcon.eEXCLAMATION);
            }
            finally
            {
                ApiExtHelpers.RefreshDrawing();

                if (functionImage != null)
                {
                    functionImage.Dispose();
                    functionImage = null;
                }
            }
        }

        #region Private Methods

        /// <summary>
        /// 지정된 Function에 대한 Part(Article) 이미지 생성
        /// </summary>
        /// <param name="function"></param>
        /// <param name="part"></param>
        /// <param name="imageWidth"></param>
        /// <param name="gapFromSymbol"></param>
        private static void CreateNewImage(Function function, Article part, double imageWidth, double gapFromSymbol)
        {
            string imageFileFullPath = part.Properties.ARTICLE_PICTUREFILE.IsEmpty ? string.Empty : part.Properties.ARTICLE_PICTUREFILE.ToLocaleText();

            if (string.IsNullOrWhiteSpace(imageFileFullPath))
                return;

            using (Image image = new Image())
            {
                PointD imageDimension = image.GetPhysicalDimensionOfImage(imageFileFullPath);
                PointD startPoint = function.Location;

                PointD leftPoint = new PointD(startPoint.X - imageWidth + gapFromSymbol, startPoint.Y + gapFromSymbol);
                PointD rightPoint = new PointD(leftPoint.X + imageWidth, leftPoint.Y - (imageDimension.Y * imageWidth / imageDimension.X));

                image.Create(function.Page, imageFileFullPath, leftPoint, rightPoint, true, true);
                image.WidthToHeighRatioFix = true;
                image.Properties.DESCRIPTION_ML = function.Name.GetMultiLangString();
            }
        }

        /// <summary>
        /// 지정된 Function에 대하여 이미지 박스가 이미 배치 되었는지 확인
        /// - function.FullDT 와 image.DESCRIPTION_ML를 비교하여 값이 같으면 해당 이미지 박스로 판단함
        /// </summary>
        /// <param name="function">배치하고자 하는 Function</param>
        /// <returns></returns>
        private static Image FindFunctionImage(Function function)
        {
            foreach (Image image in function.Page.AllGraphicalPlacements.OfType<Image>())
            {
                string description_ml = image.Properties.DESCRIPTION_ML.ToLocaleText(_eplanGUILanguage);

                if (description_ml.Equals(function.Name, StringComparison.OrdinalIgnoreCase))
                    return image;
            }

            return null;
        }

        #endregion
    }
}
