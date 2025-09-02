using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper.Internal;
using FluentValidation;
using SimpleBookKeepingMobile.Attributes.Interfaces;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.AbstractValidators
{
	public abstract class CommandAttributesAbstractValidator<TRequest, TResponse> :
		CommandAbstractValidator<TRequest, TResponse>
		where TRequest : ICommand<TResponse>
	{
		protected CommandAttributesAbstractValidator()
		{
			PropertyInfo[] props = typeof(TRequest).GetProperties();
			Type entityType = typeof(TRequest);
			ValidateModel(entityType, entityType, new List<PropertyInfo>());
		}

		private void ValidateModel(Type baseType, Type currentType, List<PropertyInfo> previous)
		{
			PropertyInfo[] props = currentType.GetProperties();

			foreach (PropertyInfo propertyInfo in props)
			{
				if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
				{
					List<PropertyInfo> prev;
					if (previous == null)
					{
						previous = new List<PropertyInfo>();
						prev = new List<PropertyInfo>();
					}
					else
					{
						prev = [..previous];
					}

					prev.Add(propertyInfo);
					ValidateModel(baseType, propertyInfo.PropertyType, prev);
				}
			}

			IEnumerable<PropertyInfo> propsWithAttr = props.Where(x =>
				x.GetCustomAttributes().Any(y => y is IExValidationAttribute || y is ValidationAttribute));

			
			foreach (PropertyInfo info in propsWithAttr)
			{
				List<PropertyInfo> curInfo;
				if (previous == null)
				{
					previous = new List<PropertyInfo>();
					curInfo = new List<PropertyInfo>();
				}
				else
				{
					curInfo = [.. previous];
				}

				curInfo.Add(info);
				List<ValidationAttribute> attributes = info.GetCustomAttributes().Where(x =>
						x.GetType().GetTypeInheritance().Any(i => i == typeof(ValidationAttribute))).ToList()
					.ConvertAll(x => (ValidationAttribute)x);

				Type propertyType = info.PropertyType;
				if (propertyType == typeof(DateTime))
				{
					AddRules<DateTime>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(bool))
				{
					AddRules<bool>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(Guid))
				{
					AddRules<Guid>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(int))
				{
					AddRules<int>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(short))
				{
					AddRules<short>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(string))
				{
					AddRules<string>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(string[]))
				{
					AddRules<string[]>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(decimal))
				{
					AddRules<decimal>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(DateTime?))
				{
					AddRules<DateTime?>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(bool?))
				{
					AddRules<bool?>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(Guid?))
				{
					AddRules<Guid?>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(int?))
				{
					AddRules<int?>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(short?))
				{
					AddRules<short?>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(string))
				{
					AddRules<string>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(string[]))
				{
					AddRules<string[]>(baseType, curInfo, attributes);
				}
				else if (propertyType == typeof(decimal?))
				{
					AddRules<decimal?>(baseType, curInfo, attributes);
				}
				else
				{
					throw new NotImplementedException(
						$"Validator can't validate property '{info.Name}' of class '{typeof(TRequest)}' " +
						$"because can't process '{propertyType.Name}' type");
				}
			}
		}

		private object GetValueNested(List<PropertyInfo> info, object obj)
		{
			return info.Aggregate(obj, static (current, t) => t.GetValue(current));
		}

		private void AddRules<T>(Type entityType, List<PropertyInfo> info, List<ValidationAttribute> attributes)
		{
			ParameterExpression arg = Expression.Parameter(entityType, "x");
			Expression property = arg;
			foreach (PropertyInfo propertyInfo in info)
			{
				property = Expression.Property(property, propertyInfo.Name);
			}

			var name = string.Join(".", info.Select(x => x.Name));
			Expression<Func<TRequest, T>> exp = Expression.Lambda<Func<TRequest, T>>(property, arg);

			foreach (ValidationAttribute attribute in attributes)
			{
				if (string.IsNullOrEmpty(attribute.ErrorMessage))
				{
					attribute.ErrorMessage = "Unknown";
				}

				RuleFor(exp).Must((command, _) => attribute.IsValid(GetValueNested(info, command)))
					.WithMessage(attribute.ErrorMessage).OverridePropertyName(name);
			}
		}
	}
}
